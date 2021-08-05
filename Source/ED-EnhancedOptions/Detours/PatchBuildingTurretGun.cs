using System.Reflection;
using HarmonyLib;
using RimWorld;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x0200000C RID: 12
    internal class PatchBuildingTurretGun : Patch
    {
        // Token: 0x0600002F RID: 47 RVA: 0x00002DEC File Offset: 0x00000FEC
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var property = typeof(Building_TurretGun).GetProperty("CanSetForcedTarget",
                BindingFlags.Instance | BindingFlags.NonPublic);
            Patcher.LogNULL(property, "_RimWorld_BuildingTurretGun_CanSetForcedTarget");
            if (property is null)
            {
                return;
            }

            var getMethod = property.GetGetMethod(true);
            Patcher.LogNULL(getMethod, "_RimWorld_BuildingTurretGun_CanSetForcedTarget_Getter");
            var method = typeof(PatchBuildingTurretGun).GetMethod("CanSetForcedTargetPrefix",
                BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method, "_CanSetForcedTargetPrefix");
            harmony?.Patch(getMethod, new HarmonyMethod(method));
        }

        // Token: 0x06000030 RID: 48 RVA: 0x00002E62 File Offset: 0x00001062
        protected override string PatchDescription()
        {
            return "CanSetForcedTargetPrefix";
        }

        // Token: 0x06000031 RID: 49 RVA: 0x00002E69 File Offset: 0x00001069
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.TurretControlEnabled;
        }

        // Token: 0x06000032 RID: 50 RVA: 0x00002E75 File Offset: 0x00001075
        public static bool CanSetForcedTargetPrefix(ref bool __result, ref Building_TurretGun __instance)
        {
            if (__instance.Faction != Faction.OfPlayer)
            {
                return true;
            }

            __result = true;
            return false;
        }
    }
}
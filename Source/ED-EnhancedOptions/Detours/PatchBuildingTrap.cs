using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x0200000B RID: 11
    internal class PatchBuildingTrap : Patch
    {
        // Token: 0x0600002A RID: 42 RVA: 0x00002D4C File Offset: 0x00000F4C
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method = typeof(Building_Trap).GetMethod("CheckSpring", BindingFlags.Instance | BindingFlags.NonPublic);
            Patcher.LogNULL(method, "_RimWorld_BuildingTrap_CheckSpring");
            var method2 =
                typeof(PatchBuildingTrap).GetMethod("CheckSpringPrefix", BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method2, "_CheckSpringPrefix");
            harmony?.Patch(method, new HarmonyMethod(method2));
        }

        // Token: 0x0600002B RID: 43 RVA: 0x00002DB0 File Offset: 0x00000FB0
        protected override string PatchDescription()
        {
            return "PatchBuildingTrap";
        }

        // Token: 0x0600002C RID: 44 RVA: 0x00002DB7 File Offset: 0x00000FB7
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.SafeTrapEnabled;
        }

        // Token: 0x0600002D RID: 45 RVA: 0x00002DC3 File Offset: 0x00000FC3
        public static bool CheckSpringPrefix(Pawn p)
        {
            return p == null || p.Faction == null || p.Faction.HostileTo(Faction.OfPlayer);
        }
    }
}
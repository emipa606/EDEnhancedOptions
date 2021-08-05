using System.Reflection;
using HarmonyLib;
using RimWorld;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000017 RID: 23
    internal class PatchPlant : Patch
    {
        // Token: 0x06000062 RID: 98 RVA: 0x00003BE8 File Offset: 0x00001DE8
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var property = typeof(Plant).GetProperty("Resting", BindingFlags.Instance | BindingFlags.NonPublic);
            Patcher.LogNULL(property, "RimWorld_Plant_Resting");
            if (property is null)
            {
                return;
            }

            var getMethod = property.GetGetMethod(true);
            Patcher.LogNULL(getMethod, "RimWorld_Plant_Resting_Getter");
            var method = typeof(PatchPlant).GetMethod("RestingGetterPrefix", BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method, "_RestingGetterPrefix");
            harmony?.Patch(getMethod, new HarmonyMethod(method));
        }

        // Token: 0x06000063 RID: 99 RVA: 0x00003C5E File Offset: 0x00001E5E
        protected override string PatchDescription()
        {
            return "Plant24HEnabled";
        }

        // Token: 0x06000064 RID: 100 RVA: 0x00003C65 File Offset: 0x00001E65
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.Plant24HEnabled;
        }

        // Token: 0x06000065 RID: 101 RVA: 0x00002CCC File Offset: 0x00000ECC
        public static bool RestingGetterPrefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}
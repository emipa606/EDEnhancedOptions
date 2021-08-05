using System.Reflection;
using HarmonyLib;
using RimWorld;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x0200000D RID: 13
    internal class PatchCompBreakdownable : Patch
    {
        // Token: 0x06000034 RID: 52 RVA: 0x00002E8C File Offset: 0x0000108C
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method =
                typeof(CompBreakdownable).GetMethod("CheckForBreakdown", BindingFlags.Instance | BindingFlags.Public);
            Patcher.LogNULL(method, "_CompBreakdownable_CheckForBreakdown");
            var method2 = typeof(PatchCompBreakdownable).GetMethod("CheckForBreakdownPrefix",
                BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method2, "_CheckForBreakdownPrefix");
            harmony?.Patch(method, new HarmonyMethod(method2));
        }

        // Token: 0x06000035 RID: 53 RVA: 0x00002EF0 File Offset: 0x000010F0
        protected override string PatchDescription()
        {
            return "PatchCompBreakdownable";
        }

        // Token: 0x06000036 RID: 54 RVA: 0x00002EF7 File Offset: 0x000010F7
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.SuppressBreakdown;
        }

        // Token: 0x06000037 RID: 55 RVA: 0x00002A17 File Offset: 0x00000C17
        public static bool CheckForBreakdownPrefix()
        {
            return false;
        }
    }
}
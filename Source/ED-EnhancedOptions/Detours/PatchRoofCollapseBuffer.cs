using System.Reflection;
using HarmonyLib;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x0200000A RID: 10
    internal class PatchRoofCollapseBuffer : Patch
    {
        // Token: 0x06000025 RID: 37 RVA: 0x00002CD4 File Offset: 0x00000ED4
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method =
                typeof(RoofCollapseBuffer).GetMethod("MarkToCollapse", BindingFlags.Instance | BindingFlags.Public);
            Patcher.LogNULL(method, "_Verse_RoofCollapseBuffer_MarkToCollapse");
            var method2 = typeof(PatchRoofCollapseBuffer).GetMethod("Supress_MarkToCollapse",
                BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method2, "_MarkToCollapsePrefix");
            harmony?.Patch(method, new HarmonyMethod(method2));
        }

        // Token: 0x06000026 RID: 38 RVA: 0x00002D38 File Offset: 0x00000F38
        protected override string PatchDescription()
        {
            return "PatchRoofCollapseBuffer";
        }

        // Token: 0x06000027 RID: 39 RVA: 0x00002D3F File Offset: 0x00000F3F
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.SuppressRoofColapse;
        }

        // Token: 0x06000028 RID: 40 RVA: 0x00002A17 File Offset: 0x00000C17
        public static bool Supress_MarkToCollapse()
        {
            return false;
        }
    }
}
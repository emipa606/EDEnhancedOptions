using System.Reflection;
using HarmonyLib;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000011 RID: 17
    internal class PatchTimeControls : Patch
    {
        // Token: 0x0600004A RID: 74 RVA: 0x000034C4 File Offset: 0x000016C4
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method = typeof(TimeControls).GetMethod("DoTimeControlsGUI", BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method, "_RimWorld_TimeControls_DoTimeControlsGUI");
            var method2 =
                typeof(TimeControls).GetMethod("DoTimeControlsGUI", BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method2, "_DoTimeControlsGUIPrefix");
            harmony?.Patch(method, new HarmonyMethod(method2));
        }

        // Token: 0x0600004B RID: 75 RVA: 0x00003528 File Offset: 0x00001728
        protected override string PatchDescription()
        {
            return "Speed4WithoutDev";
        }

        // Token: 0x0600004C RID: 76 RVA: 0x0000352F File Offset: 0x0000172F
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.Speed4WithoutDev;
        }
    }
}
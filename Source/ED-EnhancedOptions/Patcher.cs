using System.Collections.Generic;
using EnhancedDevelopment.EnhancedOptions.Detours;
using HarmonyLib;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions
{
    // Token: 0x02000003 RID: 3
    [StaticConstructorOnStartup]
    internal class Patcher
    {
        // Token: 0x06000006 RID: 6 RVA: 0x000020C0 File Offset: 0x000002C0
        static Patcher()
        {
            var str = "EnhancedOptions.Patcher.Patcher(): ";
            Log.Message(str + "Starting Patching.");
            var list = new List<Patch>
            {
                new PatchDebug(),
                new PatchBuildingTrap(),
                new PatchBuildingTurretGun(),
                new PatchCompBreakdownable(),
                new PatchCompSchedule(),
                new PatchLetterStack(),
                new PatchMainTabsRoot(),
                new PatchPlant(),
                new PatchPowerNetGraphics(),
                new PatchTimeControls(),
                new PatchTimeSlower(),
                new PatchRoofCollapseBuffer(),
                new PatchFireWatcher(),
                new PatchSkillRecord(),
                new PatchSkillUI(),
                new PatchPreventGreatMemoryTrait()
            };
            var _Harmony = new Harmony("EnhancedDevelopment.WarningOptions");
            list.ForEach(delegate(Patch p) { p.ApplyPatchIfRequired(_Harmony); });
            Log.Message(str + "Completed Patching.");
        }

        // Token: 0x06000007 RID: 7 RVA: 0x000021CF File Offset: 0x000003CF
        public static void LogNULL(object objectToTest, string name, bool logSucess = false)
        {
            if (objectToTest == null)
            {
                Log.Error(name + " Is NULL.");
                return;
            }

            if (logSucess)
            {
                Log.Message(name + " Is Not NULL.");
            }
        }

        // Token: 0x06000008 RID: 8 RVA: 0x000021FA File Offset: 0x000003FA
        public static void LogMessageIfVerbose(string messageToLog)
        {
            if (Prefs.LogVerbose)
            {
                Log.Message(messageToLog);
            }
        }
    }
}
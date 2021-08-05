using System.Reflection;
using HarmonyLib;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000010 RID: 16
    internal class PatchTimeSlower : Patch
    {
        // Token: 0x06000045 RID: 69 RVA: 0x00003418 File Offset: 0x00001618
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method =
                typeof(TimeSlower).GetMethod("SignalForceNormalSpeed", BindingFlags.Instance | BindingFlags.Public);
            Patcher.LogNULL(method, "_Verse_TimeSlower_SignalForceNormalSpeed");
            var method2 = typeof(TimeSlower).GetMethod("SignalForceNormalSpeedShort",
                BindingFlags.Instance | BindingFlags.Public);
            Patcher.LogNULL(method2, "_Verse_TimeSlower_SignalForceNormalSpeedShort");
            var method3 =
                typeof(PatchTimeSlower).GetMethod("PreventRunningPrefix", BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method3, "_PreventRunningPrefix");
            if (harmony == null)
            {
                return;
            }

            harmony.Patch(method, new HarmonyMethod(method3));
            harmony.Patch(method2, new HarmonyMethod(method3));
        }

        // Token: 0x06000046 RID: 70 RVA: 0x000034B0 File Offset: 0x000016B0
        protected override string PatchDescription()
        {
            return "SuppressCombatSlowdown";
        }

        // Token: 0x06000047 RID: 71 RVA: 0x000034B7 File Offset: 0x000016B7
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.SuppressCombatSlowdown;
        }

        // Token: 0x06000048 RID: 72 RVA: 0x00002A17 File Offset: 0x00000C17
        public static bool PreventRunningPrefix()
        {
            return false;
        }
    }
}
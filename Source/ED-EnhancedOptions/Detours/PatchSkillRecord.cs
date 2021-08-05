using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000008 RID: 8
    internal class PatchSkillRecord : Patch
    {
        // Token: 0x0600001A RID: 26 RVA: 0x00002A70 File Offset: 0x00000C70
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method = typeof(SkillRecord).GetMethod("LearnRateFactor", BindingFlags.Instance | BindingFlags.Public);
            Patcher.LogNULL(method, "_RimWorld_SkillRecord_LearnRateFactor");
            var method2 =
                typeof(PatchSkillRecord).GetMethod("LearnRateFactorPrefix", BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method2, "_LearnRateFactorPrefix");
            harmony?.Patch(method, new HarmonyMethod(method2));
            if (Mod_EnhancedOptions.Settings.PreventSkillDecay)
            {
                var method3 = typeof(SkillRecord).GetMethod("Interval", BindingFlags.Instance | BindingFlags.Public);
                Patcher.LogNULL(method3, "_RimWorld_SkillRecord_Interval");
                var method4 =
                    typeof(PatchSkillRecord).GetMethod("IntervalPrefix", BindingFlags.Static | BindingFlags.Public);
                Patcher.LogNULL(method4, "_RimWorld_SkillRecord_Interval_Prefix");
                harmony?.Patch(method3, new HarmonyMethod(method4));
                return;
            }

            Log.Message("Skipping PreventSkillDecay");
        }

        // Token: 0x0600001B RID: 27 RVA: 0x00002B43 File Offset: 0x00000D43
        protected override string PatchDescription()
        {
            return "PatchSkillRecord";
        }

        // Token: 0x0600001C RID: 28 RVA: 0x00002B4A File Offset: 0x00000D4A
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.ApplyLearnChanges;
        }

        // Token: 0x0600001D RID: 29 RVA: 0x00002B58 File Offset: 0x00000D58
        public static bool LearnRateFactorPrefix(ref float __result, ref SkillRecord __instance, bool direct = false)
        {
            if (DebugSettings.fastLearning)
            {
                __result = 200f;
                return false;
            }

            float num;
            switch (__instance.passion)
            {
                case Passion.None:
                    num = Mod_EnhancedOptions.Settings.LearnFactorPassionNonePercentage / 100f;
                    break;
                case Passion.Minor:
                    num = Mod_EnhancedOptions.Settings.LearnFactorPassionMinorPercentage / 100f;
                    break;
                case Passion.Major:
                    num = Mod_EnhancedOptions.Settings.LearnFactorPassionMajorPercentage / 100f;
                    break;
                default:
                    throw new NotImplementedException("Passion level " + __instance.passion);
            }

            if (!direct)
            {
                var pawn = typeof(SkillRecord).GetField("pawn", BindingFlags.Instance | BindingFlags.NonPublic)
                    ?.GetValue(__instance) as Pawn;
                num *= pawn.GetStatValue(StatDefOf.GlobalLearningFactor);
                if (__instance.xpSinceMidnight > Mod_EnhancedOptions.Settings.DailyLearningSaturationAmmount)
                {
                    num *= 0.2f;
                }
            }

            __result = num;
            return false;
        }

        // Token: 0x0600001E RID: 30 RVA: 0x00002A17 File Offset: 0x00000C17
        public static bool IntervalPrefix()
        {
            return false;
        }
    }
}
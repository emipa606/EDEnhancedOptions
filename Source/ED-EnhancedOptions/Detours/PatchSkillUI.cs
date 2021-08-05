using System.Reflection;
using System.Text;
using HarmonyLib;
using RimWorld;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x0200000F RID: 15
    internal class PatchSkillUI : Patch
    {
        // Token: 0x06000040 RID: 64 RVA: 0x00003148 File Offset: 0x00001348
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method = typeof(SkillUI).GetMethod("GetSkillDescription", BindingFlags.Static | BindingFlags.NonPublic);
            Patcher.LogNULL(method, "_RimWorld_SkillUI_GetSkillDescription");
            var method2 = typeof(PatchSkillUI).GetMethod("GetSkillDescriptionPrefix",
                BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method2, "_GetSkillDescriptionPrefix");
            harmony?.Patch(method, new HarmonyMethod(method2));
        }

        // Token: 0x06000041 RID: 65 RVA: 0x000031AC File Offset: 0x000013AC
        protected override string PatchDescription()
        {
            return "PatchSkillUI";
        }

        // Token: 0x06000042 RID: 66 RVA: 0x00002B4A File Offset: 0x00000D4A
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.ApplyLearnChanges;
        }

        // Token: 0x06000043 RID: 67 RVA: 0x000031B4 File Offset: 0x000013B4
        public static bool GetSkillDescriptionPrefix(ref string __result, SkillRecord sk)
        {
            var stringBuilder = new StringBuilder();
            if (sk.TotallyDisabled)
            {
                stringBuilder.Append("DisabledLower".Translate().CapitalizeFirst());
            }
            else
            {
                stringBuilder.AppendLine("Level".Translate() + " " + sk.Level.ToString() + ": " + sk.LevelDescriptor);
                if (Current.ProgramState == ProgramState.Playing)
                {
                    string text = sk.Level != 20 ? "ProgressToNextLevel".Translate() : "Experience".Translate();
                    stringBuilder.AppendLine(string.Concat(text, ": ", sk.xpSinceLastLevel.ToString("F0"), " / ",
                        sk.XpRequiredForLevelUp.ToString()));
                }

                stringBuilder.Append("Passion".Translate() + ": ");
                switch (sk.passion)
                {
                    case Passion.None:
                        stringBuilder.Append("PassionNone".Translate(
                            (Mod_EnhancedOptions.Settings.LearnFactorPassionNonePercentage / 100f)
                            .ToStringPercent("F0")));
                        break;
                    case Passion.Minor:
                        stringBuilder.Append("PassionMinor".Translate(
                            (Mod_EnhancedOptions.Settings.LearnFactorPassionMinorPercentage / 100f).ToStringPercent(
                                "F0")));
                        break;
                    case Passion.Major:
                        stringBuilder.Append("PassionMajor".Translate(
                            (Mod_EnhancedOptions.Settings.LearnFactorPassionMajorPercentage / 100f).ToStringPercent(
                                "F0")));
                        break;
                }

                if (sk.xpSinceMidnight > Mod_EnhancedOptions.Settings.DailyLearningSaturationAmmount)
                {
                    stringBuilder.AppendLine();
                    stringBuilder.Append("LearnedMaxToday".Translate(sk.xpSinceMidnight,
                        Mod_EnhancedOptions.Settings.DailyLearningSaturationAmmount, 0.2f.ToStringPercent("F0")));
                }
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            stringBuilder.Append(sk.def.description);
            __result = stringBuilder.ToString();
            return false;
        }
    }
}
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000015 RID: 21
    internal class PatchLetterStack : Patch
    {
        // Token: 0x06000058 RID: 88 RVA: 0x00003968 File Offset: 0x00001B68
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method = typeof(LetterStack).GetMethod("ReceiveLetter", new[]
            {
                typeof(Letter),
                typeof(string)
            });
            Patcher.LogNULL(method, "_Verse_LetterStack_ReceiveLetter");
            var method2 =
                typeof(PatchLetterStack).GetMethod("ReceiveLetterPrefix", BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method2, "_ReceiveLetterPrefix");
            harmony?.Patch(method, new HarmonyMethod(method2));
        }

        // Token: 0x06000059 RID: 89 RVA: 0x000039EA File Offset: 0x00001BEA
        protected override string PatchDescription()
        {
            return "PatchLetterStack";
        }

        // Token: 0x0600005A RID: 90 RVA: 0x000039F1 File Offset: 0x00001BF1
        protected override bool ShouldPatchApply()
        {
            return true;
        }

        // Token: 0x0600005B RID: 91 RVA: 0x000039F4 File Offset: 0x00001BF4
        public static bool ReceiveLetterPrefix(ref Letter let)
        {
            if (Mod_EnhancedOptions.Settings.DebugLogLetters)
            {
                Log.Message("Letter DefName: '" + let.def.defName + "' Label: '" + let.label + "'");
            }

            if ((let.def == LetterDefOf.ThreatBig) & !Mod_EnhancedOptions.Settings.ShowLettersThreatBig)
            {
                return false;
            }

            if ((let.def == LetterDefOf.ThreatSmall) & !Mod_EnhancedOptions.Settings.ShowLettersThreatSmall)
            {
                return false;
            }

            if ((let.def == LetterDefOf.NegativeEvent) & !Mod_EnhancedOptions.Settings.ShowLettersNegativeEvent)
            {
                return false;
            }

            if ((let.def == LetterDefOf.NeutralEvent) & !Mod_EnhancedOptions.Settings.ShowLettersNeutralEvent)
            {
                return false;
            }

            if ((let.def == LetterDefOf.PositiveEvent) & !Mod_EnhancedOptions.Settings.ShowLettersPositiveEvent)
            {
                return false;
            }

            if (!Mod_EnhancedOptions.Settings.LetterNamesToSuppressEnabled || !Mod_EnhancedOptions.Settings
                .LetterNamesToSuppress.Split(',').ToList().Contains(let.label))
            {
                return true;
            }

            if (Mod_EnhancedOptions.Settings.DebugLogLetters)
            {
                Log.Message("Matched with LetterNamesToSuppress");
            }

            return false;
        }
    }
}
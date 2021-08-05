using System.Reflection;
using HarmonyLib;
using RimWorld;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000007 RID: 7
    internal class PatchPreventGreatMemoryTrait : Patch
    {
        // Token: 0x06000016 RID: 22 RVA: 0x00002A22 File Offset: 0x00000C22
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var field = typeof(TraitDef).GetField("commonality", BindingFlags.Instance | BindingFlags.NonPublic);
            Patcher.LogNULL(field, "_commonalityFieldInfo");
            field?.SetValue(TraitDefOf.GreatMemory, 0f);
        }

        // Token: 0x06000017 RID: 23 RVA: 0x00002A5A File Offset: 0x00000C5A
        protected override string PatchDescription()
        {
            return "PatchPreventGreatMemoryTrait";
        }

        // Token: 0x06000018 RID: 24 RVA: 0x00002A61 File Offset: 0x00000C61
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.PreventSkillDecay;
        }
    }
}
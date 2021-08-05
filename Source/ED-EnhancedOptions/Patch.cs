using HarmonyLib;

namespace EnhancedDevelopment.EnhancedOptions
{
    // Token: 0x02000002 RID: 2
    internal abstract class Patch
    {
        // Token: 0x06000001 RID: 1
        protected abstract bool ShouldPatchApply();

        // Token: 0x06000002 RID: 2
        protected abstract void ApplyPatch(Harmony harmony = null);

        // Token: 0x06000003 RID: 3
        protected abstract string PatchDescription();

        // Token: 0x06000004 RID: 4 RVA: 0x00002050 File Offset: 0x00000250
        public void ApplyPatchIfRequired(Harmony harmony = null)
        {
            var str = "EnhancedOptions.Patch.ApplyPatchIfRequired: ";
            if (ShouldPatchApply())
            {
                Patcher.LogMessageIfVerbose(str + "Applying Patch: " + PatchDescription());
                ApplyPatch(harmony);
                Patcher.LogMessageIfVerbose(str + "Applied Patch: " + PatchDescription());
                return;
            }

            Patcher.LogMessageIfVerbose(str + "Skipping Applying Patch: " + PatchDescription());
        }
    }
}
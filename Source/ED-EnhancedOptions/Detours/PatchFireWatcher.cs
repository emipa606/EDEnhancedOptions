using System.Reflection;
using HarmonyLib;
using RimWorld;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000009 RID: 9
    internal class PatchFireWatcher : Patch
    {
        // Token: 0x06000020 RID: 32 RVA: 0x00002C44 File Offset: 0x00000E44
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var property =
                typeof(FireWatcher).GetProperty("LargeFireDangerPresent", BindingFlags.Instance | BindingFlags.Public);
            Patcher.LogNULL(property, "_RimWorld_FireWatcher_LargeFireDangerPresent");
            if (property is null)
            {
                return;
            }

            var getMethod = property.GetGetMethod();
            Patcher.LogNULL(getMethod, "_RimWorld_FireWatcher_LargeFireDangerPresent_Getter");
            var method = typeof(PatchFireWatcher).GetMethod("SupressLargeFireDangerPresentPrefix",
                BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method, "_SupressLargeFireDangerPresentPrefix");
            harmony?.Patch(getMethod, new HarmonyMethod(method));
        }

        // Token: 0x06000021 RID: 33 RVA: 0x00002CB9 File Offset: 0x00000EB9
        protected override string PatchDescription()
        {
            return "PatchFireWatcher";
        }

        // Token: 0x06000022 RID: 34 RVA: 0x00002CC0 File Offset: 0x00000EC0
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.SuppressRainFire;
        }

        // Token: 0x06000023 RID: 35 RVA: 0x00002CCC File Offset: 0x00000ECC
        public static bool SupressLargeFireDangerPresentPrefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}
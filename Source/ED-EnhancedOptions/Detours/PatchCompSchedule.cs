using System.Reflection;
using HarmonyLib;
using RimWorld;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000016 RID: 22
    internal class PatchCompSchedule : Patch
    {
        // Token: 0x0600005D RID: 93 RVA: 0x00003B44 File Offset: 0x00001D44
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method =
                typeof(CompSchedule).GetMethod("RecalculateAllowed", BindingFlags.Instance | BindingFlags.Public);
            Patcher.LogNULL(method, "_CompSchedule_RecalculateAllowed");
            var method2 = typeof(PatchCompSchedule).GetMethod("RecalculateAllowedPrefix",
                BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method2, "_RecalculateAllowedPrefix");
            harmony?.Patch(method, new HarmonyMethod(method2));
        }

        // Token: 0x0600005E RID: 94 RVA: 0x00003BA8 File Offset: 0x00001DA8
        protected override string PatchDescription()
        {
            return "PatchCompSchedule(SunLamps)";
        }

        // Token: 0x0600005F RID: 95 RVA: 0x00003BAF File Offset: 0x00001DAF
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.PlantLights24HEnabled;
        }

        // Token: 0x06000060 RID: 96 RVA: 0x00003BBB File Offset: 0x00001DBB
        public static bool RecalculateAllowedPrefix(ref CompSchedule __instance)
        {
            if (__instance.parent.def.defName != "SunLamp")
            {
                return true;
            }

            __instance.Allowed = true;
            return false;
        }
    }
}
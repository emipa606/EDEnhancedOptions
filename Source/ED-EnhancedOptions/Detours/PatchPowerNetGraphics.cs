using System.Reflection;
using HarmonyLib;
using RimWorld;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000014 RID: 20
    internal class PatchPowerNetGraphics : Patch
    {
        // Token: 0x06000053 RID: 83 RVA: 0x000038EC File Offset: 0x00001AEC
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method = typeof(PowerNetGraphics).GetMethod("PrintWirePieceConnecting",
                BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method, "_PowerNetGraphics_PrintWirePieceConnecting");
            var method2 = typeof(PatchPowerNetGraphics).GetMethod("PrintWirePieceConnectingPrefix",
                BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method2, "_PrintWirePieceConnectingPrefixPrefix");
            harmony?.Patch(method, new HarmonyMethod(method2));
        }

        // Token: 0x06000054 RID: 84 RVA: 0x00003950 File Offset: 0x00001B50
        protected override string PatchDescription()
        {
            return "PatchPowerNetGraphics";
        }

        // Token: 0x06000055 RID: 85 RVA: 0x00003957 File Offset: 0x00001B57
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.HidePowerConnections;
        }

        // Token: 0x06000056 RID: 86 RVA: 0x00003963 File Offset: 0x00001B63
        public static bool PrintWirePieceConnectingPrefix(bool forPowerOverlay)
        {
            return forPowerOverlay;
        }
    }
}
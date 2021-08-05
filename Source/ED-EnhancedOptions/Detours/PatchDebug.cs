using System.Linq;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000006 RID: 6
    internal class PatchDebug : Patch
    {
        // Token: 0x06000011 RID: 17 RVA: 0x00002958 File Offset: 0x00000B58
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var list = (from x in typeof(Debug).GetMethods().ToList()
                where x.Name.Equals("Log")
                select x).ToList();
            Patcher.LogNULL(list, "_Debug_Log");
            var _LogPrefix = typeof(PatchDebug).GetMethod("LogPrefix", BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(_LogPrefix, "_LogPrefix");
            Log.Warning(
                "########## The Mod ED-EnhancedOptions is Supressing Future calls to UnityEngine.Debug.Log, This can be changed in Mod Settings. ##########");
            list.ForEach(delegate(MethodInfo x) { harmony?.Patch(x, new HarmonyMethod(_LogPrefix)); });
        }

        // Token: 0x06000012 RID: 18 RVA: 0x00002A04 File Offset: 0x00000C04
        protected override string PatchDescription()
        {
            return "Debug Log";
        }

        // Token: 0x06000013 RID: 19 RVA: 0x00002A0B File Offset: 0x00000C0B
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.SupressWritingToLogFile;
        }

        // Token: 0x06000014 RID: 20 RVA: 0x00002A17 File Offset: 0x00000C17
        public static bool LogPrefix()
        {
            return false;
        }
    }
}
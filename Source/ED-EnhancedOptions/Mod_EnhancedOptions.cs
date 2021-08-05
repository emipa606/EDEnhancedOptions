using UnityEngine;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions
{
    // Token: 0x02000004 RID: 4
    internal class Mod_EnhancedOptions : Mod
    {
        // Token: 0x04000001 RID: 1
        public static ModSettings_EnhancedOptions Settings;

        // Token: 0x0600000A RID: 10 RVA: 0x0000220A File Offset: 0x0000040A
        public Mod_EnhancedOptions(ModContentPack content) : base(content)
        {
            Settings = GetSettings<ModSettings_EnhancedOptions>();
        }

        // Token: 0x0600000B RID: 11 RVA: 0x0000221E File Offset: 0x0000041E
        public override string SettingsCategory()
        {
            return "ED-Enhanced Options";
        }

        // Token: 0x0600000C RID: 12 RVA: 0x00002225 File Offset: 0x00000425
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Settings.DoSettingsWindowContents(inRect);
        }
    }
}
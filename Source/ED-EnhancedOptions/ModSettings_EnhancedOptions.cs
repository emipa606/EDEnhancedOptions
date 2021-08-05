using UnityEngine;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions
{
    // Token: 0x02000005 RID: 5
    internal class ModSettings_EnhancedOptions : ModSettings
    {
        // Token: 0x04000005 RID: 5
        private string _Buffer_DailyLearningSaturationAmmount;

        // Token: 0x04000004 RID: 4
        private string _Buffer_LearnFactorPassionMajor;

        // Token: 0x04000003 RID: 3
        private string _Buffer_LearnFactorPassionMinor;

        // Token: 0x04000002 RID: 2
        private string _Buffer_LearnFactorPassionNone;

        // Token: 0x0400001B RID: 27
        public bool ApplyLearnChanges;

        // Token: 0x0400001F RID: 31
        public int DailyLearningSaturationAmmount = 4000;

        // Token: 0x0400000E RID: 14
        public bool DebugLogLetters;

        // Token: 0x04000013 RID: 19
        public bool HidePowerConnections;

        // Token: 0x04000017 RID: 23
        public bool HideSpots;

        // Token: 0x0400001E RID: 30
        public int LearnFactorPassionMajorPercentage = 150;

        // Token: 0x0400001D RID: 29
        public int LearnFactorPassionMinorPercentage = 100;

        // Token: 0x0400001C RID: 28
        public int LearnFactorPassionNonePercentage = 35;

        // Token: 0x0400000D RID: 13
        public string LetterNamesToSuppress = string.Empty;

        // Token: 0x0400000C RID: 12
        public bool LetterNamesToSuppressEnabled;

        // Token: 0x0400000F RID: 15
        public bool Plant24HEnabled;

        // Token: 0x04000010 RID: 16
        public bool PlantLights24HEnabled;

        // Token: 0x04000020 RID: 32
        public bool PreventSkillDecay;

        // Token: 0x04000011 RID: 17
        public bool SafeTrapEnabled;

        // Token: 0x0400000B RID: 11
        public bool ShowLettersItemStashFeeDemand = true;

        // Token: 0x04000008 RID: 8
        public bool ShowLettersNegativeEvent = true;

        // Token: 0x04000009 RID: 9
        public bool ShowLettersNeutralEvent = true;

        // Token: 0x0400000A RID: 10
        public bool ShowLettersPositiveEvent = true;

        // Token: 0x04000006 RID: 6
        public bool ShowLettersThreatBig = true;

        // Token: 0x04000007 RID: 7
        public bool ShowLettersThreatSmall = true;

        // Token: 0x04000015 RID: 21
        public bool Speed4WithoutDev;

        // Token: 0x04000014 RID: 20
        public bool SuppressBreakdown;

        // Token: 0x04000016 RID: 22
        public bool SuppressCombatSlowdown;

        // Token: 0x04000019 RID: 25
        public bool SuppressRainFire;

        // Token: 0x04000018 RID: 24
        public bool SuppressRoofColapse;

        // Token: 0x0400001A RID: 26
        public bool SupressWritingToLogFile;

        // Token: 0x04000012 RID: 18
        public bool TurretControlEnabled;

        // Token: 0x0600000D RID: 13 RVA: 0x00002234 File Offset: 0x00000434
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref ShowLettersThreatBig, "ShowLettersThreatBig", true);
            Scribe_Values.Look(ref ShowLettersThreatSmall, "ShowLettersThreatSmall", true);
            Scribe_Values.Look(ref ShowLettersNegativeEvent, "ShowLettersNegativeEvent", true);
            Scribe_Values.Look(ref ShowLettersNeutralEvent, "ShowLettersNeutralEvent", true);
            Scribe_Values.Look(ref ShowLettersPositiveEvent, "ShowLettersPositiveEvent", true);
            Scribe_Values.Look(ref ShowLettersItemStashFeeDemand, "ShowLettersItemStashFeeDemand", true);
            Scribe_Values.Look(ref LetterNamesToSuppressEnabled, "LetterNamesToSuppressEnabled");
            Scribe_Values.Look(ref LetterNamesToSuppress, "LetterNamesToSuppress", string.Empty);
            Scribe_Values.Look(ref DebugLogLetters, "DebugLogLetters");
            Scribe_Values.Look(ref Plant24HEnabled, "Plant24HEnabled");
            Scribe_Values.Look(ref PlantLights24HEnabled, "PlantLights24HEnabled");
            Scribe_Values.Look(ref SafeTrapEnabled, "SafeTrapEnabled");
            Scribe_Values.Look(ref TurretControlEnabled, "TurretControlEnabled");
            Scribe_Values.Look(ref HidePowerConnections, "HidePowerConnections");
            Scribe_Values.Look(ref SuppressBreakdown, "SuppressBreakdown");
            Scribe_Values.Look(ref Speed4WithoutDev, "Speed4WithoutDev");
            Scribe_Values.Look(ref SuppressCombatSlowdown, "SuppressCombatSlowdown");
            Scribe_Values.Look(ref HideSpots, "HideSpots");
            Scribe_Values.Look(ref SuppressRoofColapse, "SuppressRoofColapse");
            Scribe_Values.Look(ref SuppressRainFire, "SuppressRainFire");
            Scribe_Values.Look(ref SupressWritingToLogFile, "SupressWritingToLogFile");
            Scribe_Values.Look(ref ApplyLearnChanges, "ApplyLearnFactorChanges");
            Scribe_Values.Look(ref LearnFactorPassionNonePercentage, "LearnFactorPassionNonePercentage", 35);
            Scribe_Values.Look(ref LearnFactorPassionMinorPercentage, "LearnFactorPassionMinorPercentage", 100);
            Scribe_Values.Look(ref LearnFactorPassionMajorPercentage, "LearnFactorPassionMajorPercentage", 150);
            Scribe_Values.Look(ref DailyLearningSaturationAmmount, "DailyLearningSaturationAmmount", 4000);
            Scribe_Values.Look(ref PreventSkillDecay, "PreventSkillDecay");
        }

        // Token: 0x0600000E RID: 14 RVA: 0x0000243C File Offset: 0x0000063C
        public void DoSettingsWindowContents(Rect canvas)
        {
            var listing_Standard = new Listing_Standard {ColumnWidth = 275f};
            listing_Standard.Begin(canvas);
            listing_Standard.Label(
                "THESE SETTINGS ARE ONLY APPLIED WHEN RIMWORLD IS STARTED. After modifying them please restart Rimworld.");
            listing_Standard.GapLine();
            listing_Standard.Label("Letter Suppression:");
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("Show ThreatBig", ref ShowLettersThreatBig,
                "True if you want to See Any ThreatBig Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.CheckboxLabeled("Show ThreatSmall", ref ShowLettersThreatSmall,
                "True if you want to See Any ThreatSmall Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.CheckboxLabeled("Show NegativeEvent", ref ShowLettersNegativeEvent,
                "True if you want to See Any NegativeEvent Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.CheckboxLabeled("Show NeutralEvent", ref ShowLettersNeutralEvent,
                "True if you want to See Any NeutralEvent Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.CheckboxLabeled("Show PositiveEvent", ref ShowLettersPositiveEvent,
                "True if you want to See Any PositiveEvent Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.CheckboxLabeled("Show ItemStashFeeDemand", ref ShowLettersItemStashFeeDemand,
                "True if you want to See Any ItemStashFeeDemand Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("Letter Names To Suppress Enabled", ref LetterNamesToSuppressEnabled,
                "True will Hide any Letters thats Name is in the following List, False to Ignore the List. List is Comma Separated. When a Letter is Shown its Name and Type will be written to the Log.");
            LetterNamesToSuppress = listing_Standard.TextEntry(LetterNamesToSuppress, 2);
            listing_Standard.CheckboxLabeled("Write Debug Log Letters", ref DebugLogLetters,
                "True if you want to Log the Letters to the Log file, useful for finding the mane so you can suppress it.");
            listing_Standard.GapLine();
            listing_Standard.Label("Plant 24H:");
            listing_Standard.CheckboxLabeled("Plant 24H", ref Plant24HEnabled,
                "Enable to allow Plants to Grow 24H a day.");
            listing_Standard.CheckboxLabeled("Plant Lights 24H", ref PlantLights24HEnabled,
                "Enable to allow SunLamps to Shine 24H a day.");
            listing_Standard.GapLine();
            listing_Standard.Label("Safe Trap Enabled:");
            listing_Standard.CheckboxLabeled("Safe Trap Enabled", ref SafeTrapEnabled,
                "Prevents Traps from triggering on your Colonists.");
            listing_Standard.GapLine();
            listing_Standard.Label("Turret Control Enabled:");
            listing_Standard.CheckboxLabeled("Turret Control Enabled", ref TurretControlEnabled,
                "Allows force attack commands to be given to turrets.");
            listing_Standard.GapLine();
            listing_Standard.Label("Hide Power Connections:");
            listing_Standard.CheckboxLabeled("Hide Power Connections", ref HidePowerConnections,
                "Hides the Small Power Connection Wires, Still show in Power overlay Mode.");
            listing_Standard.GapLine();
            listing_Standard.Label("Suppress Breakdown:");
            listing_Standard.CheckboxLabeled("Suppress Breakdown", ref SuppressBreakdown,
                "Suppress random Breakdowns, This was hard to test so please let me know if you have any issues.");
            listing_Standard.GapLine();
            listing_Standard.Label("Time Speed:");
            listing_Standard.CheckboxLabeled("Allow Speed4 Without Dev Mode", ref Speed4WithoutDev,
                "Allow Speed4 Without Dev Mode needing to be enabled, can be turned on by pressing '4'.");
            listing_Standard.CheckboxLabeled("Suppress Combat Slowdown", ref SuppressCombatSlowdown,
                "Suppress Limiting Speed in Combat.");
            listing_Standard.GapLine();
            listing_Standard.Label("Hide Spots:");
            listing_Standard.CheckboxLabeled("Hide Spots", ref HideSpots,
                "Stops Marriage, Caravan Packing and Party Spots from being show all the time. They will still show when Architect menu is open or one of the spots is the first thing selected. (Only checks when menu is changed)");
            listing_Standard.GapLine();
            listing_Standard.Label("Suppress Roof Colapse");
            listing_Standard.CheckboxLabeled("Suppress Roof Colapse", ref SuppressRoofColapse,
                "Stops the Roof from Collapsing when support Pillars are removed.");
            listing_Standard.GapLine();
            listing_Standard.Label("Suppress Rain Fire");
            listing_Standard.CheckboxLabeled("Suppress Rain Fire", ref SuppressRainFire,
                "Stops Fires from Causing Rain, Warning can burn the whole map and large fires can cause lag when they are burning.");
            listing_Standard.NewColumn();
            listing_Standard.GapLine();
            listing_Standard.Label("Log File");
            listing_Standard.CheckboxLabeled("Supress Writing Log to File-Tooltip", ref SupressWritingToLogFile,
                "When Checked log messages will no longer be written to disk.If you are using this because your log file is getting massive that indicated errors that you should really fix(or report to mod/ game developers to fix). But if you are not going to do that then you may as well use this so you don’t have to deal with Multi GB Log files cluttering you HDD/ SSD and wearing them out and it might even increase performance ingame for you, but really it would be better if you could go fix the errors.");
            listing_Standard.GapLine();
            listing_Standard.Label("Learning Speed Percentages:");
            listing_Standard.CheckboxLabeled("Learning Changes", ref ApplyLearnChanges,
                "Must be enabled to apply the following settings.");
            if (ApplyLearnChanges)
            {
                DrawPassionPercentage(listing_Standard, "No Passion%: ", ref LearnFactorPassionNonePercentage,
                    ref _Buffer_LearnFactorPassionNone, 35);
                DrawPassionPercentage(listing_Standard, "Minor Pass%: ", ref LearnFactorPassionMinorPercentage,
                    ref _Buffer_LearnFactorPassionMinor, 100);
                DrawPassionPercentage(listing_Standard, "Major Pass%: ", ref LearnFactorPassionMajorPercentage,
                    ref _Buffer_LearnFactorPassionMajor, 150);
                DrawPassionPercentage(listing_Standard, "Daily Cap: ", ref DailyLearningSaturationAmmount,
                    ref _Buffer_DailyLearningSaturationAmmount, 4000);
                listing_Standard.CheckboxLabeled("Stop Decay and GreatMemory Trait", ref PreventSkillDecay,
                    "Stops Skill Decay and GreatMemory Trait.");
            }

            listing_Standard.GapLine();
            listing_Standard.End();
        }

        // Token: 0x0600000F RID: 15 RVA: 0x0000286C File Offset: 0x00000A6C
        private void DrawPassionPercentage(Listing_Standard parentListing, string description,
            ref int passionPercentage, ref string buffer, int defaultValue)
        {
            var rect = parentListing.GetRect(30f);
            buffer = null;
            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(rect.LeftPartPixels(190f));
            listing_Standard.TextFieldNumericLabeled(description, ref passionPercentage, ref buffer);
            listing_Standard.End();
            var listing_Standard2 = new Listing_Standard();
            listing_Standard2.Begin(rect.RightPartPixels(75f));
            listing_Standard2.IntSetter(ref passionPercentage, defaultValue, "Default");
            listing_Standard2.End();
        }
    }
}
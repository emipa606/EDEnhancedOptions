using UnityEngine;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000013 RID: 19
    [StaticConstructorOnStartup]
    internal class TexButton
    {
        // Token: 0x04000024 RID: 36
        public static readonly Texture2D[] SpeedButtonTextures =
        {
            ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Pause"),
            ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Normal"),
            ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Fast"),
            ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Superfast"),
            ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Superfast")
        };
    }
}
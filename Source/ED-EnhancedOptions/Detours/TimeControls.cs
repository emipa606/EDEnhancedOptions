using System;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x02000012 RID: 18
    public static class TimeControls
    {
        // Token: 0x04000021 RID: 33
        public static readonly Vector2 TimeButSize = new Vector2(32f, 24f);

        // Token: 0x04000022 RID: 34
        private static readonly string[] SpeedSounds =
        {
            "ClockStop",
            "ClockNormal",
            "ClockFast",
            "ClockSuperfast",
            "ClockSuperfast"
        };

        // Token: 0x04000023 RID: 35
        private static readonly TimeSpeed[] CachedTimeSpeedValues = (TimeSpeed[]) Enum.GetValues(typeof(TimeSpeed));

        // Token: 0x0600004E RID: 78 RVA: 0x0000353C File Offset: 0x0000173C
        private static void PlaySoundOf(TimeSpeed speed)
        {
            SoundDef soundDef = null;
            switch (speed)
            {
                case TimeSpeed.Paused:
                    soundDef = SoundDefOf.Clock_Stop;
                    break;
                case TimeSpeed.Normal:
                    soundDef = SoundDefOf.Clock_Normal;
                    break;
                case TimeSpeed.Fast:
                    soundDef = SoundDefOf.Clock_Fast;
                    break;
                case TimeSpeed.Superfast:
                    soundDef = SoundDefOf.Clock_Superfast;
                    break;
                case TimeSpeed.Ultrafast:
                    soundDef = SoundDefOf.Clock_Superfast;
                    break;
            }

            if (soundDef != null)
            {
                soundDef.PlayOneShotOnCamera();
            }
        }

        // Token: 0x0600004F RID: 79 RVA: 0x00003598 File Offset: 0x00001798
        public static bool DoTimeControlsGUI(Rect timerRect)
        {
            var tickManager = Find.TickManager;
            GUI.BeginGroup(timerRect);
            var x = TimeButSize.x;
            var timeButSize = TimeButSize;
            var rect = new Rect(0f, 0f, x, timeButSize.y);
            foreach (var timeSpeed in CachedTimeSpeedValues)
            {
                if (timeSpeed == TimeSpeed.Ultrafast)
                {
                    continue;
                }

                if (Widgets.ButtonImage(rect, TexButton.SpeedButtonTextures[(int) timeSpeed]))
                {
                    tickManager.CurTimeSpeed = timeSpeed;
                    PlayerKnowledgeDatabase.KnowledgeDemonstrated(ConceptDefOf.TimeControls,
                        KnowledgeAmount.SpecificInteraction);

                    PlaySoundOf(tickManager.CurTimeSpeed);
                }

                if (tickManager.CurTimeSpeed == timeSpeed)
                {
                    GUI.DrawTexture(rect, TexUI.HighlightTex);
                }

                rect.x += rect.width;
            }

            if (Find.TickManager.slower.ForcedNormalSpeed)
            {
                Widgets.DrawLineHorizontal(rect.width * 2f, rect.height / 2f, rect.width * 2f);
            }

            GUI.EndGroup();
            GenUI.AbsorbClicksInRect(timerRect);
            UIHighlighter.HighlightOpportunity(timerRect, "TimeControls");
            if (Event.current.type != EventType.KeyDown)
            {
                return false;
            }

            if (KeyBindingDefOf.TogglePause.KeyDownEvent)
            {
                Find.TickManager.TogglePaused();
                PlaySoundOf(Find.TickManager.CurTimeSpeed);
                PlayerKnowledgeDatabase.KnowledgeDemonstrated(ConceptDefOf.Pause,
                    KnowledgeAmount.SpecificInteraction);
                Event.current.Use();
            }

            if (KeyBindingDefOf.TimeSpeed_Normal.KeyDownEvent)
            {
                Find.TickManager.CurTimeSpeed = TimeSpeed.Normal;
                PlaySoundOf(Find.TickManager.CurTimeSpeed);
                PlayerKnowledgeDatabase.KnowledgeDemonstrated(ConceptDefOf.TimeControls,
                    KnowledgeAmount.SpecificInteraction);
                Event.current.Use();
            }

            if (KeyBindingDefOf.TimeSpeed_Fast.KeyDownEvent)
            {
                Find.TickManager.CurTimeSpeed = TimeSpeed.Fast;
                PlaySoundOf(Find.TickManager.CurTimeSpeed);
                PlayerKnowledgeDatabase.KnowledgeDemonstrated(ConceptDefOf.TimeControls,
                    KnowledgeAmount.SpecificInteraction);
                Event.current.Use();
            }

            if (KeyBindingDefOf.TimeSpeed_Superfast.KeyDownEvent)
            {
                Find.TickManager.CurTimeSpeed = TimeSpeed.Superfast;
                PlaySoundOf(Find.TickManager.CurTimeSpeed);
                PlayerKnowledgeDatabase.KnowledgeDemonstrated(ConceptDefOf.TimeControls,
                    KnowledgeAmount.SpecificInteraction);
                Event.current.Use();
            }

            if (KeyBindingDefOf.TimeSpeed_Ultrafast.KeyDownEvent)
            {
                Find.TickManager.CurTimeSpeed = TimeSpeed.Ultrafast;
                PlaySoundOf(Find.TickManager.CurTimeSpeed);
                Event.current.Use();
            }

            if (!KeyBindingDefOf.Dev_TickOnce.KeyDownEvent)
            {
                return false;
            }

            tickManager.DoSingleTick();
            SoundDefOf.Clock_Stop.PlayOneShotOnCamera();

            return false;
        }
    }
}
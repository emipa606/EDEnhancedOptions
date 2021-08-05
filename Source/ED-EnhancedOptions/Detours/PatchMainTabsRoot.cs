using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions.Detours
{
    // Token: 0x0200000E RID: 14
    internal class PatchMainTabsRoot : Patch
    {
        // Token: 0x06000039 RID: 57 RVA: 0x00002F03 File Offset: 0x00001103
        protected override bool ShouldPatchApply()
        {
            return Mod_EnhancedOptions.Settings.HideSpots;
        }

        // Token: 0x0600003A RID: 58 RVA: 0x00002F10 File Offset: 0x00001110
        protected override void ApplyPatch(Harmony harmony = null)
        {
            var method = typeof(MainTabsRoot).GetMethod("ToggleTab", BindingFlags.Instance | BindingFlags.Public);
            Patcher.LogNULL(method, "_Building_MainTabsRoot_ToggleTab");
            var method2 =
                typeof(PatchMainTabsRoot).GetMethod("SetDrawStatusPostfix", BindingFlags.Static | BindingFlags.Public);
            Patcher.LogNULL(method2, "_SetDrawStatusPostfix");
            harmony?.Patch(method, null, new HarmonyMethod(method2));
        }

        // Token: 0x0600003B RID: 59 RVA: 0x00002F74 File Offset: 0x00001174
        protected override string PatchDescription()
        {
            return "PatchMainTabsRoot - HideSpots";
        }

        // Token: 0x0600003C RID: 60 RVA: 0x00002F7C File Offset: 0x0000117C
        public static void SetDrawStatusPostfix(MainTabsRoot __instance)
        {
            if (ShouldShowSpots(__instance))
            {
                ThingDefOf.MarriageSpot.drawerType = DrawerType.MapMeshAndRealTime;
                ThingDefOf.CaravanPackingSpot.drawerType = DrawerType.MapMeshAndRealTime;
                ThingDefOf.PartySpot.drawerType = DrawerType.MapMeshAndRealTime;
                MarkMapMeshAsDirty();
                return;
            }

            ThingDefOf.MarriageSpot.drawerType = DrawerType.None;
            ThingDefOf.CaravanPackingSpot.drawerType = DrawerType.None;
            ThingDefOf.PartySpot.drawerType = DrawerType.None;
            MarkMapMeshAsDirty();
        }

        // Token: 0x0600003D RID: 61 RVA: 0x00002FE0 File Offset: 0x000011E0
        public static bool ShouldShowSpots(MainTabsRoot __instance)
        {
            if (__instance.OpenTab == null)
            {
                return false;
            }

            if (string.Equals(__instance.OpenTab.defName, "Architect"))
            {
                return true;
            }

            if (!string.Equals(__instance.OpenTab.defName, "Inspect"))
            {
                return false;
            }

            if (Find.Selector.FirstSelectedObject is Thing thing && (string.Equals(thing.def.defName, "MarriageSpot") ||
                                                                     string.Equals(thing.def.defName, "PartySpot") ||
                                                                     string.Equals(thing.def.defName,
                                                                         "CaravanPackingSpot")))
            {
                return true;
            }

            return false;
        }

        // Token: 0x0600003E RID: 62 RVA: 0x00003084 File Offset: 0x00001284
        public static void MarkMapMeshAsDirty()
        {
            Find.CurrentMap.listerBuildings.AllBuildingsColonistOfDef(ThingDefOf.MarriageSpot).ToList().ForEach(
                delegate(Building x) { Find.CurrentMap.mapDrawer.MapMeshDirty(x.Position, MapMeshFlag.Things); });
            Find.CurrentMap.listerBuildings.AllBuildingsColonistOfDef(ThingDefOf.CaravanPackingSpot).ToList().ForEach(
                delegate(Building x) { Find.CurrentMap.mapDrawer.MapMeshDirty(x.Position, MapMeshFlag.Things); });
            Find.CurrentMap.listerBuildings.AllBuildingsColonistOfDef(ThingDefOf.PartySpot).ToList().ForEach(
                delegate(Building x) { Find.CurrentMap.mapDrawer.MapMeshDirty(x.Position, MapMeshFlag.Things); });
        }
    }
}
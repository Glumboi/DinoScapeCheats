using Il2Cpp;
using MelonLoader;
using HarmonyLib;

namespace DinoScapeMelonMod.Patches
{
    [HarmonyPatch(typeof(IncubatorManager))]
    internal static class IncubatorManagerPatches
    {
        public static IncubatorManager incuInstance;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        private static void Postfix_Awake(IncubatorManager __instance)
        {
            incuInstance = __instance;
        }

        public static void SetEggTypeGoalMeters(int m)
        {
            var egg = incuInstance.selectedEgg;
            if (incuInstance != null)
            {
                if (egg != null)
                {
                    incuInstance.selectedEgg.goalMeters = m;
                    MelonLogger.Msg("Trying to set an eggs goal...");
                    return;
                }

                MelonLogger.Msg("No selected egg found!");
                return;
            }

            MelonLogger.Msg("No incubator instance found!");
        }

        public static void HatchSelectedEgg()
        {
            var egg = incuInstance.selectedEgg;
            if (incuInstance != null)
            {
                if (egg != null)
                {
                    incuInstance.selectedEgg.Hatch();
                    MelonLogger.Msg("Trying to hatch an egg...");
                    return;
                }

                MelonLogger.Msg("No selected egg found!");
                return;
            }

            MelonLogger.Msg("No incubator instance found!");
        }
    }
}
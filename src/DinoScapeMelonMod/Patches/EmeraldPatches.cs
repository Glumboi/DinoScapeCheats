using System;
using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace DinoScapeMelonMod.Patches
{
    [HarmonyPatch(typeof(Emerald))]
    internal static class EmeraldPatches
    {
        public static bool patchRewards = false;
        public static int minReward = 8000;
        public static int maxReward = 19356;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void Postfix_Start(Emerald __instance)
        {
            if (patchRewards)
            {
                var rnd = new Random();
                int newVal = rnd.Next(minReward, maxReward);
                MelonLogger.Msg(
                    $"Patching one coin's value from: {__instance.coinValue} to: {__instance.coinValue += newVal}");
                __instance.coinValue = newVal;
            }
        }
    }
}
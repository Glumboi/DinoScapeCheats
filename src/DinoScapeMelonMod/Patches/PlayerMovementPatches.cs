using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace DinoScapeMelonMod.Patches
{
    [HarmonyPatch(typeof(PlayerMovement))]
    internal static class PlayerMovementPatches
    {
        public static bool boost = false;
        public static float boostMp = 2.1f;

        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        private static void Prefix_Update(PlayerMovement __instance)
        {
            if (boost)
            {
                __instance.runSpeed = __instance.runSpeedBase * boostMp;
            }
            else
            {
                __instance.runSpeed = __instance.runSpeedBase;
            }
        }
    }
}
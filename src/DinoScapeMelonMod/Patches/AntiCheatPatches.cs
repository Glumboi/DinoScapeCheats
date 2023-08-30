using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace DinoScapeMelonMod.Patches
{
    [HarmonyPatch(typeof(AntiCheat))]
    internal static class AntiCheatPatches
    {
        [HarmonyPatch("isComputer")]
        [HarmonyPrefix]
        private static bool Prefix_isComputer(AntiCheat __instance)
        {
            MelonLogger.Msg("Spoofing anticheat...");
            return false;
        }
    }
}
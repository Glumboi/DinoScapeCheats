using HarmonyLib;
using Il2Cpp;

namespace DinoScapeMelonMod.Patches
{
    [HarmonyPatch(typeof(ZoneMove))]
    internal static class ZonePatches
    {
        public static bool zoneDontMove = false;

        [HarmonyPatch("Start")]
        [HarmonyPrefix]
        private static void Prefix_Start(ZoneMove __instance)
        {
            __instance.DontMove = zoneDontMove;
        }
    }
}
using System;
using Il2Cpp;
using HarmonyLib;

namespace DinoScapeMelonMod.Patches
{
    [HarmonyPatch(typeof(DinoEgg))]
    internal static class DinoEggPatches
    {
        public static bool cheatAmber = false;
        public static int cheatAmberAmount = 999;

        [HarmonyPatch("GrantContent", new Type[] { typeof(DinoEgg.EggContent) })]
        [HarmonyPrefix]
        private static void Prefix_GrantContent(DinoEgg.EggContent content)
        {
            if (cheatAmber)
            {
                content.amount = cheatAmberAmount;
                content.contenttype = DinoEgg.EggContent.ContentTypes.Currency;
            }
        }
    }
}
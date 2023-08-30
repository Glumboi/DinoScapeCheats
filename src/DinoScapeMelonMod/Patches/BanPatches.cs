using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace DinoScapeMelonMod.Patches
{
    //works sometimes
    [HarmonyPatch(typeof(CheckForBan))]
    internal static class BanPatches
    {
        [HarmonyPatch("Start")]
        [HarmonyPrefix]
        private static void Prefix_Start(CheckForBan __instance)
        {
            MelonLogger.Msg(
                $"[From Start method of CheckForBan] User banned original : {__instance.banned} User banned new: {false}");
            __instance.banned = false;
        }

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        private static void Postfix_Awake(CheckForBan __instance)
        {
            var obj = new GameObject();
            obj.name = "Generic CheatManager";
            GameInstances.cM = obj.AddComponent<CheatManager>();
            MelonLogger.Msg($"Created a CheatManager with the name of: {GameInstances.cM.name}");

            var obj2 = new GameObject();
            obj2.name = "Generic ChangeDisplayname object";
            GameInstances.cDN = obj2.AddComponent<ChangeDisplayname>();
            MelonLogger.Msg($"Created a ChangeDisplayname object with the name of: {GameInstances.cDN.name}");
        }

        [HarmonyPatch("CheckBan")]
        [HarmonyPrefix]
        private static void Prefix_CheckBan(CheckForBan __instance)
        {
            __instance.banned = false;
            return;
        }
    }
}
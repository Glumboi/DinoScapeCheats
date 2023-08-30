using Il2CppPlayFab.ClientModels;
using Il2CppPlayFab.Events;
using MelonLoader;
using HarmonyLib;

namespace DinoScapeMelonMod.Patches
{
    [HarmonyPatch(typeof(PlayFabEvents))]
    internal static class PlayFabEventsPatches
    {
        [HarmonyPatch("add_OnGetAccountInfoResultEvent",
            new[] { typeof(PlayFabEvents.PlayFabResultEvent<GetAccountInfoResult>) })]
        [HarmonyPrefix]
        private static void Prefix_add_OnGetAccountInfoResultEvent(PlayFabEvents __instance,
            PlayFabEvents.PlayFabResultEvent<GetAccountInfoResult> value)
        {
            MelonLogger.Msg("add_OnGetAccountInfoResultEvent");
        }
    }
}
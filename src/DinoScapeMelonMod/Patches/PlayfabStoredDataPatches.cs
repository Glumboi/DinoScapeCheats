using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace DinoScapeMelonMod.Patches
{
    [HarmonyPatch(typeof(PlayfabStoredData))]
    internal static class PlayfabStoredDataPatches
    {
        public static PlayfabStoredData instance;

        //Acc info
        /*[HarmonyPatch(typeof(PlayfabStoredData), "_GetPlayerData_b__18_0", new Type[] { typeof(GetAccountInfoResult) })]
        [HarmonyPostfix]
        static void Postfix__GetPlayerData_b__18_0(PlayfabStoredData __instance, GetAccountInfoResult result)
        {
            MelonLogger.Msg(
                "\nAPI get account info: " +
                $"\nCreated: {result.AccountInfo.Created}" +
                $"\nUsername: {result.AccountInfo.Username}" +
                $"\nEmail: {result.AccountInfo.PrivateInfo.Email}" +
                $"\nPlayFabId: {result.AccountInfo.PlayFabId}");
        }

        //Inventory
        [HarmonyPatch(typeof(PlayfabStoredData), "_GetPlayerData_b__18_2",
            new Type[] { typeof(GetUserInventoryResult) })]
        [HarmonyPostfix]
        static void Postfix__GetPlayerData_b__18_2(PlayfabStoredData __instance, GetUserInventoryResult result)
        {
            MelonLogger.Msg(
                "\nAPI get account info: " +
                $"\nInvetory size: {result.Inventory._size}" +
                $"\nCurency count: {result.VirtualCurrency.count}");
        }

        //UserData
        [HarmonyPatch(typeof(PlayfabStoredData), "_GetPlayerData_b__18_4",
            new Type[] { typeof(Il2CppPlayFab.ClientModels.GetUserDataResult) })]
        [HarmonyPostfix]
        static void Postfix__GetPlayerData_b__18_4(PlayfabStoredData __instance,
            Il2CppPlayFab.ClientModels.GetUserDataResult result)
        {
        } */

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        private static void Postfix_Awake(PlayfabStoredData __instance)
        {
            instance = __instance;
            MelonLogger.Msg("Initialized PlayfabStoredData");
        }
    }
}
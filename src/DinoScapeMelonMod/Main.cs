using System;
using System.Threading;
using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;
using Random = System.Random;

namespace DinoScapeMelonMod
{
    public static class BuildInfo
    {
        public const string Name = "DinoScapeMelonMod"; // Name of the Mod.  (MUST BE SET)

        public const string
            Description = "Mod that enables some cheats for you"; // Description for the Mod.  (Set as null if none)

        public const string Author = "Glumboi"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class DinoScapeMelonMod : MelonMod
    {
        private static bool menuEnabled;

        public override void OnUpdate() // Runs once per frame.
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                ToggleMenu();
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                PlayerMovementPatches.boost = !PlayerMovementPatches.boost;
            }
        }

        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
            if (menuEnabled)
            {
                UI.DoMyWindow();
            }
        }
        
        public static void ToggleMenu()
        { 
            menuEnabled = !menuEnabled;
        }
    }

    [HarmonyPatch(typeof(ZoneMove))]
    internal static class ZonePatches
    {
        public static bool zoneDontMove = false;
        
        [HarmonyPatch(typeof(ZoneMove), "Start")]
        [HarmonyPrefix]
        static void Prefix_Start(ZoneMove __instance)
        {
            __instance.DontMove = zoneDontMove;
        }
    }


    [HarmonyPatch(typeof(GetDisplayname))]
    internal static class GetDisplaynamePatches
    {
        public static GetDisplayname displayNameInstance;
        public static string newUsername = string.Empty;

        [HarmonyPatch(typeof(GetDisplayname), "Start")]
        [HarmonyPrefix]
        static void Prefix_Start(GetDisplayname __instance)
        {
            displayNameInstance = __instance;
        }
    }

    //works sometimes
    [HarmonyPatch(typeof(CheckForBan))]
    internal static class BanPatches
    {
        [HarmonyPatch(typeof(CheckForBan), "Start")]
        [HarmonyPrefix]
        static void Prefix_Start(CheckForBan __instance)
        {
            MelonLogger.Msg(
                $"[From Start method of CheckForBan] User banned original : {__instance.banned} User banned new: {false}");
            __instance.banned = false;
        }

        [HarmonyPatch(typeof(CheckForBan), "Awake")]
        [HarmonyPostfix]
        static void Postfix_Awake(CheckForBan __instance)
        {
            var obj = new GameObject();
            obj.name = "Generic CheatManager";
            GameInstances.cM = obj.AddComponent<CheatManager>();
            MelonLogger.Msg($"Created a CheatManager with the name of: {GameInstances.cM.name}");
        }

        [HarmonyPatch(typeof(CheckForBan), "CheckBan")]
        [HarmonyPrefix]
        static void Prefix_CheckBan(CheckForBan __instance)
        {
            MelonLogger.Msg(
                $"[From CheckBan method of CheckForBan] User banned original : {__instance.banned} User banned new: {false}");

            __instance.banned = false;
        }
    }

    [HarmonyPatch(typeof(Emerald))]
    internal static class EmeraldPatches
    {
        public static bool patchRewards = false;
        public static int minReward = 8000;
        public static int maxReward = 19356;
        
        [HarmonyPatch(typeof(Emerald), "Start")]
        [HarmonyPostfix]
        static void Postfix_Start(Emerald __instance)
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

    [HarmonyPatch(typeof(PlayerMovement))]
    internal static class PlayerMovementPatches
    {
        public static bool boost = false;
        public static float boostMp = 2.1f;

        [HarmonyPatch(typeof(PlayerMovement), "Update")]
        [HarmonyPrefix]
        static void Prefix_Update(PlayerMovement __instance)
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

    [HarmonyPatch(typeof(AntiCheat))]
    internal static class AntiCheatPatches
    {
        [HarmonyPatch(typeof(AntiCheat), "isComputer")]
        [HarmonyPrefix]
        static bool Prefix_isComputer(AntiCheat __instance)
        {
            MelonLogger.Msg("Spoofing anticheat...");
            return false;
        }
    }

    [HarmonyPatch(typeof(IncubatorManager))]
    internal static class IncubatorManagerPatches
    {
        public static IncubatorManager incuInstance;
        
        [HarmonyPatch(typeof(IncubatorManager), "Awake")]
        [HarmonyPostfix]
        static void Postfix_Awake(IncubatorManager __instance)
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
    
    [HarmonyPatch(typeof(DinoEgg))]
    internal static class DinoEggPatches
    {
        public static bool cheatAmber = false;
        public static int cheatAmberAmount = 999;
        
        [HarmonyPatch(typeof(DinoEgg), "GrantContent", new Type[] {typeof(DinoEgg.EggContent)})]
        [HarmonyPrefix]
        static void Prefix_GrantContent(DinoEgg.EggContent content)
        {
            if (cheatAmber)
            {
                content.amount = cheatAmberAmount;
                content.contenttype = DinoEgg.EggContent.ContentTypes.Currency;
            }
        }
    }
}
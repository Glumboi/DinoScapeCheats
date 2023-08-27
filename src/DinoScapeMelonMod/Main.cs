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
        public const string Description = "Mod that enables some cheats for you"; // Description for the Mod.  (Set as null if none)
        public const string Author = "Glumboi"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class DinoScapeMelonMod : MelonMod
    {
        private bool menuEnabled;
        private Rect windowRect = new Rect(20, 20, 350, 620);

        public override void OnUpdate() // Runs once per frame.
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                menuEnabled = !menuEnabled;
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
    }
    
    [HarmonyPatch(typeof(ZoneMove))]
    internal static class ZonePatches
    {
        [HarmonyPatch(typeof(ZoneMove), "Start")]
        [HarmonyPrefix]
        static void Prefix_Start(ZoneMove __instance)
        {
            MelonLogger.Msg("Disabling zone movement...");
            __instance.DontMove = true;
        }
    }

        
    [HarmonyPatch(typeof(GetDisplayname))]
    internal static class GetDisplaynamePatches
    {
        public static GetDisplayname displayNameInstance;
        
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
        [HarmonyPatch(typeof(Emerald), "Start")]
        [HarmonyPostfix]
        static void Postfix_Start(Emerald __instance)
        {
            var rnd = new Random();
            int addVal = rnd.Next(8000, 19356);
            MelonLogger.Msg($"Patching one coin's value from: {__instance.coinValue} to: {__instance.coinValue += addVal}");
            __instance.coinValue += addVal;
        }
    }    
    
    [HarmonyPatch(typeof(PlayerMovement))]
    internal static class PlayerMovementPatches
    {
        public static bool boost = false;
        
        [HarmonyPatch(typeof(PlayerMovement), "Update")]
        [HarmonyPrefix]
        static void Prefix_Update(PlayerMovement __instance)
        {
            if (boost)
            {
                __instance.runSpeed = __instance.runSpeedBase * 2;
            }
            else
            {
                __instance.runSpeed = __instance.runSpeedBase;
            }
        }
    }
}
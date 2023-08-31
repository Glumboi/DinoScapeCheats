using DinoScapeMelonMod.Patches;
using MelonLoader;
using UnityEngine;

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
        public static int fpsLimit = -1;

        public override void OnUpdate() // Runs once per frame.
        {
            Application.targetFrameRate = fpsLimit;

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
                UI.MenuUI();
            }
        }

        public static void ToggleMenu()
        {
            menuEnabled = !menuEnabled;
        }
    }
}
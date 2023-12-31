﻿using System;
using DinoScapeMelonMod.Patches;
using MelonLoader;
using UnityEngine;

namespace DinoScapeMelonMod
{
    internal static class UI
    {
        public static void MenuUI()
        {
            GUILayout.BeginVertical(GUI.skin.window, GUILayout.Width(300));
            GUI.backgroundColor = new Color32(255, 0, 147, 255);
            GUI.contentColor = new Color32(0, 198, 255, 255);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Close", new GUILayoutOption[0]))
            {
                DinoScapeMelonMod.ToggleMenu();
            }

            GUILayout.Space(6);
            GUILayout.Label("Dinoscape Cheats", new GUILayoutOption[0]);
            GUILayout.EndHorizontal();

            GUILayout.Space(6);

            if (GUILayout.Button("Fill all slots with eggs", new GUILayoutOption[0]))
            {
                for (uint i = 0; i < 6; i++)
                {
                    GameInstances.cM.GiveDinoEgg();

                    MelonLogger.Msg("Gave 1 egg from the CheatManager!");
                }
            }

            if (GUILayout.Button("Give some dino's", new GUILayoutOption[0]))
            {
                GameInstances.cM.GiveDinoBrachio();
                GameInstances.cM.GiveDinoEuplo();
                GameInstances.cM.GiveDinoTrizera();

                MelonLogger.Msg("Gave all available dino's from the CheatManager!");
            }

            if (GUILayout.Button("Hatch selected egg", new GUILayoutOption[0]))
            {
                IncubatorManagerPatches.HatchSelectedEgg();
            }

            if (GUILayout.Button("Patch all egg meters to 1M", new GUILayoutOption[0]))
            {
                IncubatorManagerPatches.SetEggTypeGoalMeters(1);
            }

            GUILayout.Space(8);
            GUILayout.Label("Collectable Emerald rewards");
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Label("Minimum reward");
            EmeraldPatches.minReward = Int32.Parse(GUILayout.TextField(EmeraldPatches.minReward.ToString()));
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Maximum reward");
            EmeraldPatches.maxReward = Int32.Parse(GUILayout.TextField(EmeraldPatches.maxReward.ToString()));
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            EmeraldPatches.patchRewards = GUILayout.Toggle(EmeraldPatches.patchRewards, "Toggle patched rewards");

            GUILayout.Space(8);
            GUILayout.Label("New username");
            GameInstances.newUsername = GUILayout.TextField(GameInstances.newUsername);
            if (GUILayout.Button("Change username", new GUILayoutOption[0]) && !string.IsNullOrWhiteSpace(GameInstances.newUsername))
            {
                GameInstances.cDN.SaveName(GameInstances.newUsername);
                MelonLogger.Msg($"Trying to change username to: {GameInstances.newUsername}");
            }

            GUILayout.Space(8);
            GUILayout.Label("Speedhack multiplier");
            PlayerMovementPatches.boostMp = float.Parse(GUILayout.TextField(PlayerMovementPatches.boostMp.ToString("0.0")));
            PlayerMovementPatches.boost = GUILayout.Toggle(PlayerMovementPatches.boost, "Toggle Speedhack");

            GUILayout.Space(8);
            GUILayout.Label("Amount of Amber/Emrald to grand on egg hatch");
            DinoEggPatches.cheatAmberAmount =
                Int32.Parse(GUILayout.TextField(DinoEggPatches.cheatAmberAmount.ToString()));
            DinoEggPatches.cheatAmber = GUILayout.Toggle(DinoEggPatches.cheatAmber, "Toggle Amber/Emrald hatch cheat");

            GUILayout.Space(8);
            GUILayout.Label("Weapon to equip");
            Menupatches.WeaponMenuPatches.selectWeaponName =
                GUILayout.TextField(Menupatches.WeaponMenuPatches.selectWeaponName);

            if (GUILayout.Button("Equip", new GUILayoutOption[0]) && Menupatches.WeaponMenuPatches.instance != null)
            {
                Menupatches.WeaponMenuPatches.EquipItemByName(Menupatches.WeaponMenuPatches.selectWeaponName);
            }

            GUILayout.Space(8);
            GUILayout.Label("Hat to equip");
            Menupatches.HatMenuPatches.selectHatName =
                GUILayout.TextField(Menupatches.HatMenuPatches.selectHatName);

            if (GUILayout.Button("Equip", new GUILayoutOption[0]) && Menupatches.HatMenuPatches.instance != null)
            {
                Menupatches.HatMenuPatches.EquipItemByName(Menupatches.HatMenuPatches.selectHatName);
            }

            GUILayout.Space(8);
            GUILayout.Label("Other settings");
            GUILayout.Space(4);
            ZonePatches.zoneDontMove =
                GUILayout.Toggle(ZonePatches.zoneDontMove, "Stop zone movement (needs a level reload)");
            GUILayout.Space(4);

            GUILayout.Label("Fps limit");
            GUILayout.Space(4);
            DinoScapeMelonMod.fpsLimit = Int32.Parse(GUILayout.TextField(DinoScapeMelonMod.fpsLimit.ToString()));

            GUILayout.EndVertical();
        }
    }
}
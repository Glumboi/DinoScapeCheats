using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2Cpp;
using MelonLoader;
using UnityEngine;
using MelonLoader;

namespace DinoScapeMelonMod
{
    internal class UI
    {
        public static void DoMyWindow()
        {
            GUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(300));
            GUI.backgroundColor = Color.red;
            
            if (GUILayout.Button("Fill all slots with eggs", new GUILayoutOption[0]))
            {
                for (int i = 0; i < 4; i++)
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
            
            if (GUILayout.Button("Change username", new GUILayoutOption[0]))
            {
                string newUserName;
                if (!File.Exists("./NewUserName.txt"))
                    File.Create("./NewUserName.txt").Close();

                newUserName = File.ReadAllText("./NewUserName.txt");
                if (!string.IsNullOrWhiteSpace(newUserName))
                {
                    GetDisplaynamePatches.displayNameInstance.SaveName(newUserName);
                }
            }
            
            GUILayout.Space(8);
            
            if (GUILayout.Button("Toggle speed boost", new GUILayoutOption[0]))
            {
                PlayerMovementPatches.boost = !PlayerMovementPatches.boost;
            }
            GUILayout.Label($"Super speed toggle state: {PlayerMovementPatches.boost}");
            GUILayout.EndVertical();
        }
    }
}
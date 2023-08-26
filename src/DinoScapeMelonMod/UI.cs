using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
            GUILayout.Space(8);
            
            if (GUILayout.Button("Toggle super speed (can cheese the leaderboards)", new GUILayoutOption[0]))
            {
                PlayerMovementPatches.boost = !PlayerMovementPatches.boost;
            }
            GUILayout.Label($"Super speed toggle state: {PlayerMovementPatches.boost}");
            GUILayout.EndVertical();
        }
    }
}
using Il2Cpp;
using HarmonyLib;
using System.Linq;
using Il2CppSystem;
using MelonLoader;
using Il2CppSystem.Security.Cryptography;
using Il2CppSystem.Text;

namespace DinoScapeMelonMod.Patches
{
    [HarmonyPatch(typeof(RoomNameGenerator))]
    internal class RoomNameGeneratorPatches
    {
        //Implement at some point

        /*private static bool customRoomNameB = false;
        private static string customRoomNameS;

        private static Random random = new Random();

        [HarmonyPatch("Generate", new[] { typeof(int) })]
        [HarmonyPostfix]
        private static string Postfix_Generate(string __result, int length)
        {
            if (customRoomNameB)
            {
                return customRoomNameS;
            }

            MelonLogger.Msg($"Glyphs: {RoomNameGenerator.glyphs}");

            __result = new string(Enumerable.Repeat(RoomNameGenerator.glyphs, length)
                                            .Select(s => s[random.Next(s.Length)]).ToArray());

            MelonLogger.Msg($"Generated room code: {__result}");

            return "Tomary123456789010";//__result;
        }*/
    }
}
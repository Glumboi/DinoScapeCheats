using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace DinoScapeMelonMod.Patches
{
    public static class Menupatches
    {
        [HarmonyPatch(typeof(WeaponMenu))]
        public static class WeaponMenuPatches
        {
            public static WeaponMenu instance;
            public static string selectWeaponName;

            [HarmonyPatch("Owned", new[] { typeof(string) })]
            [HarmonyPrefix]
            private static bool Prefix_Owned(WeaponMenu __instance, string key)
            {
                return true;
            }

            [HarmonyPatch("Start")]
            [HarmonyPrefix]
            private static void Postfix_Start(WeaponMenu __instance)
            {
                instance = __instance;

                for (int i = 0; i < instance.weapons.Count; i++)
                {
                    MelonLogger.Msg($"New available weapon: {instance.weapons[i].name} with rarity: {instance.weapons[i].eRarity}");
                }
            }

            public static void EquipItemByName(string name)
            {
                MelonModLogger.Msg($"Trying to equip: {name}");

                for (int i = 0; i < instance.weapons.Count; i++)
                {
                    if (instance.weapons[i].name == name)
                    {
                        instance.selectedWeapon = instance.weapons[i];
                        instance.cavemenEquipButton.onClick.Invoke();
                    }
                }
            }
        }

        [HarmonyPatch(typeof(HatMenu))]
        public static class HatMenuPatches
        {
            public static HatMenu instance;
            public static string selectHatName;

            [HarmonyPatch("Owned", new[] { typeof(string) })]
            [HarmonyPrefix]
            private static bool Prefix_Owned(HatMenu __instance, string key)
            {
                return true;
            }

            [HarmonyPatch("Start")]
            [HarmonyPrefix]
            private static void Postfix_Start(HatMenu __instance)
            {
                instance = __instance;

                for (int i = 0; i < instance.hats.Count; i++)
                {
                    MelonLogger.Msg($"New available hat: {instance.hats[i].name} with rarity: {instance.hats[i].eRarity}");
                }
            }

            public static void EquipItemByName(string name)
            {
                MelonModLogger.Msg($"Trying to equip: {name}");

                for (int i = 0; i < instance.hats.Count; i++)
                {
                    if (instance.hats[i].name == name)
                    {
                        instance.selectedHat = instance.hats[i];
                        instance.cavemenEquipButton.onClick.Invoke();
                        MelonModLogger.Msg($"{name} found and equipped!");
                        return;
                    }
                }

                MelonModLogger.Msg($"{name} not found!");
            }
        }
    }
}
using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace HyperbolicaPlugin
{
    internal class Hyperbolica_MainMenu
    {
        internal static GameObject modMenuButton;

        [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Start))]
        private class MainMenu_Start
        {
            private static void Prefix(MainMenu __instance)
            {
                var continueButton = __instance.continueOption;
                modMenuButton = Object.Instantiate(continueButton, continueButton.transform.parent);
                modMenuButton.name = "ModMenu";

                var text = modMenuButton.GetComponent<Text>();
                text.text = "MOD MENU";

                var button = modMenuButton.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                var pressEvent = new Button.ButtonClickedEvent();
                pressEvent.AddListener(ModMenuAction());
                button.onClick = pressEvent;
            }

            private static Action ModMenuAction()
            {
                return Listener;
                void Listener()
                {
                    HyperbolicaPlugin.LogInfo("clicked the new button");
                    // TODO open an UI with the mod settings? or just scrap the entire button approach and don't provide any settings
                }
            }
        }
    }
}

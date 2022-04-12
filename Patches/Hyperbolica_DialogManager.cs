using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperbolicaPlugin
{
    internal class Hyperbolica_DialogManager
    {
        [HarmonyPatch(typeof(DialogManager), nameof(DialogManager.GetDialog))]
        private class DialogManager_GetDialog
        {
            private static void Prefix(string dialogKey)
            {
                HyperbolicaPlugin.LogInfo("DialogManager_GetDialog_prefix: " + dialogKey);
            }

            private static void Postfix(ref string __result)
            {
                HyperbolicaPlugin.LogInfo("DialogManager_GetDialog_postfix: " + __result);
            }
        }

        [HarmonyPatch(typeof(DialogManager), nameof(DialogManager.HasDialog))]
        private class DialogManager_HasDialog
        {
            private static void Prefix(string dialogKey)
            {
                HyperbolicaPlugin.LogInfo("DialogManager_HasDialog_prefix: " + dialogKey);
            }

            private static void Postfix(ref bool __result)
            {
                HyperbolicaPlugin.LogInfo("DialogManager_HasDialog_postfix: " + __result);
            }
        }

        [HarmonyPatch(typeof(DialogManager), nameof(DialogManager.HasMoreStates))]
        private class DialogManager_HasMoreStates
        {
            private static void Prefix(string dialogKey)
            {
                HyperbolicaPlugin.LogInfo("DialogManager_HasMoreStates_prefix: " + dialogKey);
            }

            private static void Postfix(ref bool __result)
            {
                HyperbolicaPlugin.LogInfo("DialogManager_HasMoreStates_postfix: " + __result);
            }
        }

        [HarmonyPatch(typeof(DialogManager), nameof(DialogManager.GetStatedKey))]
        private class DialogManager_GetStatedKey
        {
            private static void Prefix(string dialogKey, bool cycle)
            {
                HyperbolicaPlugin.LogInfo($"DialogManager_GetStatedKey_prefix: {dialogKey} {cycle}");
            }

            private static void Postfix(ref string __result)
            {
                HyperbolicaPlugin.LogInfo("DialogManager_GetStatedKey_postfix: " + __result);
            }
        }

        [HarmonyPatch(typeof(DialogManager), nameof(DialogManager.GetStateSuffixKey))]
        private class DialogManager_GetStateSuffixKey
        {
            private static void Prefix(string dialogKey)
            {
                HyperbolicaPlugin.LogInfo("DialogManager_GetStateSuffixKey_prefix: " + dialogKey);
            }

            private static void Postfix(ref string __result)
            {
                HyperbolicaPlugin.LogInfo("DialogManager_GetStateSuffixKey_postfix: " + __result);
            }
        }

        [HarmonyPatch(typeof(DialogManager), nameof(DialogManager.OnNextText))]
        private class DialogManager_OnNextText
        {
            private static void Prefix()
            {
                HyperbolicaPlugin.LogInfo("DialogManager_OnNextText_prefix");
            }
        }
    }
}

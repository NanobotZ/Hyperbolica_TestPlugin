using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.SceneManagement;

namespace HyperbolicaPlugin
{
    internal class Unity_SceneManager
    {
        [HarmonyPatch(typeof(SceneManager), nameof(SceneManager.Internal_SceneLoaded))]
        private class SceneManager_Internal_SceneLoaded
        {
            private static void Prefix(Scene scene, LoadSceneMode mode)
            {
                HyperbolicaPlugin.LogInfo($"SceneManager_Internal_SceneLoaded_prefix: {scene.name} {mode}");

                if (scene.name == "Over")
                {
                    OverworldModifications.OnOverLoaded();
                }
            }
        }
    }
}

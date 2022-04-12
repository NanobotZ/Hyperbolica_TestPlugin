using BepInEx.IL2CPP.UnityEngine;
using HarmonyLib;

namespace HyperbolicaPlugin
{
    internal class HyperAssembly_PlayerPatches
    {
        [HarmonyPatch(typeof(Player), nameof(Player.IsGrounded))]
        private class Player_IsGrounded
        {
            private static bool Prefix(ref bool __result)
            {
                if (Input.GetKeyInt(KeyCode.V))
                {
                    // I hoped this would allow me to jump in air (double, triple jump etc), but all I've noticed is being able to talk to robots or using any interactables (portals, trinkets etc) in the air
                    __result = true;
                    return false;
                }

                return true;
            }
        }

        [HarmonyPatch(typeof(Player), nameof(Player.Update))]
        private class Player_Update
        {
            private static void Prefix(Player __instance)
            {
                if (Input.GetKeyInt(KeyCode.O))
                {
                    __instance.walkingSpeed += UnityEngine.Input.mouseScrollDelta.y;
                }
                else if (Input.GetKeyInt(KeyCode.P))
                {
                    __instance.jumpSpeed += UnityEngine.Input.mouseScrollDelta.y;
                }
            }
        }
    }
}

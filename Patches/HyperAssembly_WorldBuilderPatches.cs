using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using System;
using UnhollowerBaseLib;
using UnityEngine;

namespace HyperbolicaPlugin
{
    internal class HyperAssembly_WorldBuilderPatches
    {
        private static string firstTileName = null;
        private static GameObject firstTileGO = null;
        private static bool logging = false;
        private static bool messWithTheTiles = false;

        [HarmonyPatch(typeof(WorldBuilder), nameof(WorldBuilder.MakeTile), new Type[] { typeof(string), typeof(Dictionary<string, GameObject>) })]
        private class WorldBuilder_MakeTile
        {
            private static void Prefix(ref string tileStr, Dictionary<string, GameObject> map)
            {
                if (logging)
                {
                    var log = "WorldBuilder_MakeTile_prefix: " + tileStr + Environment.NewLine;
                    log += "map: ";
                    foreach (var kvp in map)
                    {
                        log += kvp.Key + " ";
                    }
                    log += Environment.NewLine;

                    HyperbolicaPlugin.LogInfo(log);
                }

                if (messWithTheTiles)
                {
                    if (firstTileName == null)
                        firstTileName = tileStr;
                    else
                        tileStr = firstTileName;
                }
            }

            private static void Postfix(GameObject __result)
            {
                if (logging)
                {
                    HyperbolicaPlugin.LogInfo($"WorldBuilder_MakeTile_postfix: " + __result.name + Environment.NewLine);
                }

                if (messWithTheTiles)
                {
                    if (firstTileGO == null)
                        firstTileGO = __result;
                }
            }
        }

        [HarmonyPatch(typeof(WorldBuilder), nameof(WorldBuilder.MakeRandomTile), new Type[] { typeof(Il2CppReferenceArray<GameObject>), typeof(string) })]
        private class WorldBuilder_MakeRandomTile1
        {
            private static bool Prefix(ref Il2CppReferenceArray<GameObject> tiles, string coord)
            {
                if (logging)
                {
                    var log = $"WorldBuilder_MakeRandomTile1_prefix: " + coord + Environment.NewLine;
                    log += "tiles: ";
                    foreach (var gameObject in tiles)
                    {
                        log += gameObject.name + " ";
                    }
                    log += Environment.NewLine;

                    HyperbolicaPlugin.LogInfo(log);
                }

                if (messWithTheTiles)
                {
                    tiles = new Il2CppReferenceArray<GameObject>(new GameObject[] { firstTileGO });
                }

                return true;
            }
        }

        [HarmonyPatch(typeof(WorldBuilder), nameof(WorldBuilder.MakeRandomTile), new Type[] { typeof(Dictionary<string, GameObject>), typeof(Il2CppStringArray), typeof(string) })]
        private class WorldBuilder_MakeRandomTile2
        {
            private static bool Prefix(Dictionary<string, GameObject> map, ref Il2CppStringArray tiles, string coord)
            {
                if (logging)
                {
                    var log = $"WorldBuilder_MakeRandomTile2_prefix: " + coord + Environment.NewLine;
                    log += "map: ";
                    foreach (var kvp in map)
                    {
                        log += kvp.Key + " ";
                    }
                    log += Environment.NewLine + "tiles: ";
                    foreach (var tile in tiles)
                    {
                        log += tile + " ";
                    }
                    log += Environment.NewLine;

                    HyperbolicaPlugin.LogInfo(log);
                }

                if (messWithTheTiles)
                {
                    tiles = new Il2CppStringArray(new string[] { firstTileName });
                }

                return true;
            }
        }

        [HarmonyPatch(typeof(WorldBuilder), nameof(WorldBuilder.MakeRandomTileAndRotate), new Type[] { typeof(Il2CppReferenceArray<GameObject>), typeof(string) })]
        private class WorldBuilder_MakeRandomTileAndRotate1
        {
            private static bool Prefix(ref Il2CppReferenceArray<GameObject> tiles, string coord)
            {
                if (logging)
                {
                    var log = $"WorldBuilder_MakeRandomTileAndRotate1_prefix: " + coord + Environment.NewLine;
                    log += "tiles: ";
                    foreach (var gameObject in tiles)
                    {
                        log += gameObject.name + " ";
                    }
                    log += Environment.NewLine;

                    HyperbolicaPlugin.LogInfo(log);
                }

                if (messWithTheTiles)
                {
                    tiles = new Il2CppReferenceArray<GameObject>(new GameObject[] { firstTileGO });
                }

                return true;
            }
        }

        [HarmonyPatch(typeof(WorldBuilder), nameof(WorldBuilder.MakeRandomTileAndRotate), new Type[] { typeof(Dictionary<string, GameObject>), typeof(Il2CppStringArray), typeof(string) })]
        private class WorldBuilder_MakeRandomTileAndRotate2
        {
            private static bool Prefix(Dictionary<string, GameObject> map, ref Il2CppStringArray tiles, string coord)
            {
                if (logging)
                {
                    var log = $"WorldBuilder_MakeRandomTileAndRotate2_prefix: " + coord + Environment.NewLine;
                    log += "map: ";
                    foreach (var kvp in map)
                    {
                        log += kvp.Key + " ";
                    }
                    log += Environment.NewLine + "tiles: ";
                    foreach (var tile in tiles)
                    {
                        log += tile + " ";
                    }
                    log += Environment.NewLine;

                    HyperbolicaPlugin.LogInfo(log);
                }

                if (messWithTheTiles)
                {
                    tiles = new Il2CppStringArray(new string[] { firstTileName });
                }

                return true;
            }
        }
    }
}

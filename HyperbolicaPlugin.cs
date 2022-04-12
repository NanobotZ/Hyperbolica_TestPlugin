using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using System.Linq;

namespace HyperbolicaPlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class HyperbolicaPlugin : BasePlugin
    {
        public static HyperbolicaPlugin Instance { get; private set; }

        private Harmony _harmony;

        public override void Load()
        {
            Instance = this;

            _harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            _harmony.PatchAll();

            // Plugin startup logic
            LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded with {_harmony.GetPatchedMethods().Count()} Harmony patches!");
        }

        public static void LogInfo(string message)
        {
            Instance.Log.LogInfo(message);
        }
    }
}

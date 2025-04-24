using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Rendering;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ScuvLib
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

        /// <summary>
        /// The Scuvlib plugin instance.
        /// </summary>
        public static Plugin Instance { get; private set; } = null!;

#pragma warning disable IDE0051 // Remove unused private members
        private void Awake()
#pragma warning restore IDE0051 // Remove unused private members
        {
            Instance = this;

            ScuvLib.Logger.Initialize(BepInEx.Logging.Logger.CreateLogSource(MyPluginInfo.PLUGIN_GUID));
            ScuvLib.Logger.LogInfo($"{MyPluginInfo.PLUGIN_NAME} has awoken!");

            ConfigManager.Initialize(Config);

            BundleLoader.LoadAllBundles(Paths.PluginPath, ".scavbundle");
        }

    }
}

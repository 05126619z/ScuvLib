using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Rendering;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SkateScav
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "05126619z.SkateScav";
        private const string modName = "SkateScav";
        private const string modVersion = "1.0.0";

        public static ManualLogSource logger;
        private Harmony harmony;
        public static AssetBundle MyAssetBundle { get; private set; }
        public static string AssetsFolderPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");

        public void Awake()
        {
            MyAssetBundle = AssetBundle.LoadFromFile(Path.Combine(AssetsFolderPath, "myassetbundle"));
            logger = Logger;
            //logger.LogInfo(Plugin.MyAssetBundle.LoadAsset<AudioClip>("assets/sounds/lobotomy.mp3"));
            harmony = new Harmony(modGUID);
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {modName} is loaded!");
        }

    }
}

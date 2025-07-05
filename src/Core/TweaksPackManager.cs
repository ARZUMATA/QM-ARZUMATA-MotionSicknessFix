using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using static MGSC.Localization;

namespace QM_TweaksPack
{
    internal partial class TweaksPackManager
    {
        public static OrbitPlanetTweak orbitPlanetTweak = new OrbitPlanetTweak();
        public static Spaceship spaceship;
        public static SpaceGameMode spaceGameMode;

        [Hook(ModHookType.SpaceStarted)]
        public static void SpaceStarted(IModContext context)
        {
            Plugin.Logger.Log("SpaceStarted");
            orbitPlanetTweak.Initialize(context);
        }

        [Hook(ModHookType.SpaceUpdateBeforeGameLoop)]
        public static void SpaceStarted2(IModContext context)
        {
            orbitPlanetTweak.StopOrbiting();
        }

        // [Hook(ModHookType.MainMenuStarted)]
        // public static void MainMenuStarted(IModContext context)
        // {
        //     //Plugin.Logger.Log("MainMenuStarted");
        // }

        // [Hook(ModHookType.DungeonStarted)]
        // public static void DungeonStarted(IModContext context)
        // {
        //     //Plugin.Logger.Log("DungeonStarted");
        // }

        // [Hook(ModHookType.DungeonFinished)]
        // public static void DungeonFinished(IModContext context)
        // {
        //     //ModConfiguration.ModEnabled = false;
        //     //ModConfiguration.IsInitialized = false;
        //     //dungeonGameMode = null;
        // }

        // [Hook(ModHookType.DungeonUpdateBeforeGameLoop)]
        // public static void DungeonUpdateBeforeGameLoop(IModContext context)
        // {
        //     //ModConfiguration.ModEnabled = Plugin.Config.ModEnabled;

        //     if (Plugin.Config.CompanionsFollowFloors)
        //     {
        //         return;
        //     }

        //     //Initialize();
        //     ////MakeAlliedMobsMoveAcrossFloors();
        //     //TryMoveMob();
        // }

    }
}

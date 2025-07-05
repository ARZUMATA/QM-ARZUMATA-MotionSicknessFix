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
    internal partial class BetterCompanions
    {
        private static Player player = null;

        private static void MakeAlliedMobsMoveAcrossFloors(Creatures creatures)
        {
            //monsters.Clear();

            if (player == null)
            {
                player = creatures.Player;
            }

            foreach (Creature creature in creatures.Monsters)
            {
                var monster = (Monster)creature;

                if (creature.IsAlly(player))
                {
                    Plugin.Logger.Log($"name: {monster.name}");

                    Plugin.Logger.Log($"IsTransferable: {monster.IsTransferable}");
                    Plugin.Logger.Log($"CreatureClass: {monster.CreatureData.CreatureClass}");
                    Plugin.Logger.Log($"CreatureAlliance: {monster.CreatureData.CreatureAlliance}");
                    Plugin.Logger.Log($"ActionPoints: {monster.ActionPoints}");
                    Plugin.Logger.Log($"ActionPointsLeft: {monster.ActionPointsLeft}");
                    Plugin.Logger.Log($"ActionPointsProcessed: {monster.ActionPointsProcessed}");

                    //monsters.Add(monster);

                    if (!monster.IsTransferable && monster.CreatureData != null && monster.CreatureData.Immobile)
                    {
                        monster.IsTransferable = true;
                    }
                }
            }
        }
    }
}
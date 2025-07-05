using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM_TweaksPack
{
    internal class OrbitPlanetTweak
    {

        public static bool isBlockingCamera = true;

        internal void Initialize(IModContext context)
        {
            Plugin.Logger.Log($"OrbitPlanetTweak: Initialize");

            if (TweaksPackManager.spaceship == null)
            {
                Plugin.Logger.Log($"\tLooking for SpaceShip state as of {TweaksPackManager.spaceship}");
                TweaksPackManager.spaceship = context.State.Get<Spaceship>();
                Plugin.Logger.Log($"\tSpaceship found: {TweaksPackManager.spaceship != null}");
            }

            if (TweaksPackManager.spaceGameMode == null)
            {
                Plugin.Logger.Log($"\tLooking for SpaceGameMode state as of {TweaksPackManager.spaceGameMode}");
                TweaksPackManager.spaceGameMode = context.State.Get<SpaceGameMode>();
                Plugin.Logger.Log($"\tSpaceGameMode found: {TweaksPackManager.spaceGameMode != null}");
            }

            StopOrbiting();
        }

        internal void StopOrbiting()
        {
            if (TweaksPackManager.spaceGameMode == null)
            {
                return;
            }
           
            //spaceship._elasticAfterDelayTimer.Pause(); // If you rotate camera, it snaps back.
            //spaceship._currentOrbit = null; // Blocks travel
        }
    }
}

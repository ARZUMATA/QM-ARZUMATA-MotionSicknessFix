using MGSC;

namespace QM_MotionSicknessFix
{
    internal partial class MotionSicknessFix
    {
        public static Spaceship spaceship;
        public static SpaceGameMode spaceGameMode;

        public static bool isBlockingCamera = true;

        internal static void Initialize(IModContext context)
        {
            Plugin.Logger.Log($"OrbitPlanetTweak: Initialize");

            if (MotionSicknessFix.spaceship == null)
            {
                Plugin.Logger.Log($"\tLooking for SpaceShip state as of {MotionSicknessFix.spaceship}");
                MotionSicknessFix.spaceship = context.State.Get<Spaceship>();
                Plugin.Logger.Log($"\tSpaceship found: {MotionSicknessFix.spaceship != null}");
            }

            if (MotionSicknessFix.spaceGameMode == null)
            {
                Plugin.Logger.Log($"\tLooking for SpaceGameMode state as of {MotionSicknessFix.spaceGameMode}");
                MotionSicknessFix.spaceGameMode = context.State.Get<SpaceGameMode>();
                Plugin.Logger.Log($"\tSpaceGameMode found: {MotionSicknessFix.spaceGameMode != null}");
            }

            StopOrbiting();
        }

        internal static void StopOrbiting()
        {
            if (MotionSicknessFix.spaceGameMode == null)
            {
                return;
            }

            //spaceship._elasticAfterDelayTimer.Pause(); // If you rotate camera, it snaps back.
            //spaceship._currentOrbit = null; // Blocks travel
        }

        [Hook(ModHookType.SpaceStarted)]
        public static void SpaceStarted(IModContext context)
        {
            Plugin.Logger.Log("SpaceStarted");
            Initialize(context);
        }

        [Hook(ModHookType.SpaceUpdateBeforeGameLoop)]
        public static void SpaceStarted2(IModContext context)
        {
            StopOrbiting();
        }
    }
}

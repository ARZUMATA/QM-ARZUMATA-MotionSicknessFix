using HarmonyLib;
using MGSC;

namespace QM_MotionSicknessFix
{
    internal partial class MotionSicknessFix
    {
        [HarmonyPatch(typeof(TravelSystem), "StartSpaceshipTravel")]
        public static class TravelSystem_StartSpaceshipTravel_Patch
        {
            public static bool Prefix()
            {
                if (Plugin.Config.CameraOrbitPlanetDisable == true)
                {
                    isBlockingCamera = false;

                    if (MotionSicknessFix.spaceship != null)
                    {
                        MotionSicknessFix.spaceship.DisableShipScreenCamera();
                    }
                }

                return true;
            }
        }
    }
}

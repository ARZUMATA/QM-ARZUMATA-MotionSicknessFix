using HarmonyLib;
using MGSC;

namespace QM_TweaksPack
{
    internal partial class TweaksPackManager
    {
        [HarmonyPatch(typeof(TravelSystem), "StartSpaceshipTravel")]
        public static class TravelSystem_StartSpaceshipTravel_Patch
        {
            public static bool Prefix()
            {
                if (Plugin.Config.CameraOrbitPlanetDisable == true)
                {
                    OrbitPlanetTweak.isBlockingCamera = false;

                    if (TweaksPackManager.spaceship != null)
                    {
                        TweaksPackManager.spaceship.DisableShipScreenCamera();
                    }
                }

                return true;
            }
        }
    }
}

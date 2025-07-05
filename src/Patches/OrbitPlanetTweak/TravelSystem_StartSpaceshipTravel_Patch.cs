using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

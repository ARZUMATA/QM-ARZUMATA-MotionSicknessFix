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
        [HarmonyPatch(typeof(Spaceship), "Awake")]
        public static class Spaceship_Awake_Patch
        {
            public static void Postfix(Spaceship __instance)
            {
                if (Plugin.Config.CameraOrbitPlanetDisable == true)
                {
                    //__instance.UpdatePosition = false; // Stops ship in space (other object slowly "drift" away, skybox static though)

                    OrbitPlanetTweak.isBlockingCamera = true;
                    if (__instance._cameraManager != null)
                    {
                        __instance._cameraManager.SetSpaceShipScreenCamera();

                        Plugin.Logger.Log($"Spaceship_Awake_Patch");
                        Plugin.Logger.Log($"__instance==null {__instance == null}");
                        Plugin.Logger.Log($"__instance._cameraManager {__instance._cameraManager == null}");
                    }
                }
            }
        }
    }
}

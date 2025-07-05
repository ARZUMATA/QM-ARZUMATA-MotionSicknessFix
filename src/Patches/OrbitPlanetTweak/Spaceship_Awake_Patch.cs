using HarmonyLib;
using MGSC;

namespace QM_MotionSicknessFix
{
    internal partial class MotionSicknessFix
    {
        [HarmonyPatch(typeof(Spaceship), "Awake")]
        public static class Spaceship_Awake_Patch
        {
            public static void Postfix(Spaceship __instance)
            {
                if (Plugin.Config.CameraOrbitPlanetDisable == true)
                {
                    //__instance.UpdatePosition = false; // Stops ship in space (other object slowly "drift" away, skybox static though)

                    isBlockingCamera = true;
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

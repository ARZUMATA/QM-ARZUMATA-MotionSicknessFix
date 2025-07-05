using HarmonyLib;
using MGSC;

namespace QM_MotionSicknessFix
{
    internal partial class MotionSicknessFix
    {
        [HarmonyPatch(typeof(Spaceship), "DisableShipScreenCamera")]
        public static class Spaceship_DisableShipScreenCamera_Patch
        {
            public static bool Prefix(Spaceship __instance)
            {
                //if (Plugin.Config.CameraOrbitPlanetDisable == true && isBlockingCamera == true && !__instance._isInModuleView)
                //{
                //    return false;
                //}

                return true;
            }

            public static void Postfix(Spaceship __instance)
            {
                if (Plugin.Config.CameraOrbitPlanetDisable == true && isBlockingCamera == true)
                {
                    __instance._cameraManager.SetSpaceShipScreenCamera();
                }
            }
        }
    }
}

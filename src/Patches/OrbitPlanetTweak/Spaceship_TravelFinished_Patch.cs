using HarmonyLib;
using MGSC;

namespace QM_MotionSicknessFix
{
    internal partial class MotionSicknessFix
    {
        [HarmonyPatch(typeof(Spaceship), "TravelFinished")]
        public static class Spaceship_TravelFinished_Patch
        {
            public static void Postfix(Spaceship __instance)
            {
                if (Plugin.Config.CameraOrbitPlanetDisable == true)
                {
                    isBlockingCamera = true;
                    __instance._cameraManager.SetSpaceShipScreenCamera();
                }
            }
        }
    }
}

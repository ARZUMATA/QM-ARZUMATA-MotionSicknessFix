using HarmonyLib;
using MGSC;

namespace QM_TweaksPack
{
    internal partial class TweaksPackManager
    {
        [HarmonyPatch(typeof(Spaceship), "TravelFinished")]
        public static class Spaceship_TravelFinished_Patch
        {
            public static void Postfix(Spaceship __instance)
            {
                if (Plugin.Config.CameraOrbitPlanetDisable == true)
                {
                    OrbitPlanetTweak.isBlockingCamera = true;
                    __instance._cameraManager.SetSpaceShipScreenCamera();
                }
            }
        }
    }
}

using HarmonyLib;
using MGSC;
using System;

namespace QM_MotionSicknessFix
{
    internal partial class MotionSicknessFix
    {
        [HarmonyPatch(typeof(CameraRotator),
            nameof(CameraRotator.HandleZoomInput),
            new Type[]
            {
            }
        )]
        public static class CameraRotator_HandleZoomInput_Patch
        {
            public static bool Prefix(CameraRotator __instance)
            {
                if (__instance._framingTransposer == null)
                {
                    return false;
                }

                return true;
            }
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class Vibrations : MonoBehaviour
{

   private  void PlayFallVibrate()
   {
      MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
   }
   
   public void TestVibration()
   {
      MMVibrationManager.Vibrate();
   }
   
   
   public void PlayFailureVibration()
   {
      MMVibrationManager.Haptic(HapticTypes.Failure,false,true);
   }
   
   public  void PlaySlowDestroyVibrate()
   {
      MMVibrationManager.Vibrate();
   }

    
   public  void PlayFastDestroyVibrate()
   {
      MMVibrationManager.Haptic(HapticTypes.Warning);
   }
}

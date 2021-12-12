using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.NiceVibrations
{
    public class NiceVibrationsDemoManager : MonoBehaviour
    {
        /// a text object in the demo scene in which debug information will be displayed

        protected string _debugString;
        protected string _platformString;
        protected const string _CURRENTVERSION = "1.7";
        
        protected virtual void Awake()
        {
            MMNViOS.iOSInitializeHaptics();
        }

       
        public virtual void TriggerDefault()
        {
#if UNITY_IOS || UNITY_ANDROID
				Handheld.Vibrate ();	
#endif
        }

      
        public virtual void TriggerVibrate()
        {
            MMVibrationManager.Vibrate();
        }

    
        public virtual void TriggerWarning()
        {
            MMVibrationManager.Haptic(HapticTypes.Warning);
        }

      
        public virtual void TriggerHeavyImpact()
        {
            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelComplitedPanel : MonoBehaviour
{
   [SerializeField] private ParticleSystem _confetie;
   public event UnityAction Opened;
   
   private void OnEnable()
   {
      PlayEffect();
      Opened?.Invoke();
   }

   private void PlayEffect()
   {
      _confetie.Play();
   }
}

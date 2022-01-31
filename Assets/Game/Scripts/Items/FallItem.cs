using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallItem : Item
{
    [SerializeField] private ParticleSystem _touchEffect;
    
    public event UnityAction TouchedFallItem;
    protected override void Break(GameObject legPivot)
    {
        TouchedFallItem?.Invoke();
          _touchEffect.Play();
        
    }
}

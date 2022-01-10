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
       Debug.Log("каснулись");
        
        //Desrtoyed();
        
        TouchedFallItem?.Invoke();
        
       /* if (legPivot.transform.position.y<TopPoint.transform.localPosition.y)
        {
            Discard();
            Debug.Log("отлетел");
       }
        else
        {
            TouchedFallItem?.Invoke();
            _touchEffect.Play();
            Debug.Log("также упал");
        }*/
    }
}

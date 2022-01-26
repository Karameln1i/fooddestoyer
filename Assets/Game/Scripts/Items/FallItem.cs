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

        //Desrtoyed();
        
        TouchedFallItem?.Invoke();
          _touchEffect.Play();
        
       /* if (legPivot.transform.position.y<TopPoint.transform.localPosition.y)
        {
            Discard();
            Debug.Log("отлетел");
       }
        else
        {
            TouchedFallItem?.Invoke();
          
            Debug.Log("также упал");
        }*/
    }
}

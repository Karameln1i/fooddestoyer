using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallItem : Item
{
    [SerializeField] private GameObject _topPoint;
    
    public event UnityAction TouchedFallItem;
    protected override void Break(GameObject legPivot)
    {
       // Debug.Log("каснулись");
        //TouchedFallItem?.Invoke();
        //Desrtoyed();
        
        if (legPivot.transform.position.y<_topPoint.transform.localPosition.y)
        {
            Discard();
            Debug.Log("отлетел");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallItem : Item
{
    public event UnityAction TouchedFallItem;
    protected override void Break(GameObject legPivot)
    {
       Debug.Log("каснулись");
        
        //Desrtoyed();
        
        Debug.Log("legPivot "+legPivot.transform.position.y);
        Debug.Log("TopPoint "+TopPoint.transform.localPosition.y);
        
        if (legPivot.transform.position.y<TopPoint.transform.localPosition.y)
        {
            Discard();
            Debug.Log("отлетел");
       }
        else
        {
            TouchedFallItem?.Invoke();
            Debug.Log("также упал");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallItem : Item
{
    public event UnityAction TouchedFallItem;
    protected override void Break()
    {
        Debug.Log("каснулись");
        TouchedFallItem?.Invoke();
        Desrtoyed();
    }
}

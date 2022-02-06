using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollisionHandler : MonoBehaviour
{
    private Item _item;
    
    private void Awake()
    {
        _item = GetComponent<Item>();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerFoot>(out PlayerFoot playerFoot))
        {
            _item.Liquidate(playerFoot.GetSpeedForFlatting(),playerFoot.LegPivot,playerFoot.GetСondition());
            _item.Deform(playerFoot.GetSpeedForFlatting(),playerFoot.LegPivot,playerFoot.GetСondition());
        }
    }
}

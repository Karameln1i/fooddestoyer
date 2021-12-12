using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColdier : MonoBehaviour
{
    [SerializeField] private GameObject _topPoint;
    [SerializeField] private Item _item;

    public Vector3 GetTopPointPosition()
    {
        return _topPoint.transform.position;
    }
    
    public Item GetItem()
    {
        return _item;
    }
}

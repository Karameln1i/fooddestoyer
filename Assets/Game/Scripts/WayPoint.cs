using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private GameObject _legTarget;
    [SerializeField] private Item _item;
    [SerializeField] private bool _isFallItemWaypoit;
    [SerializeField] private FlyingWithJuiceItem _flyingWithJuiceItem;
    [SerializeField] private bool _isFlyingWithJuiceItemWayPoint;

    public bool IsFallItemWaypoit => _isFallItemWaypoit;
    public bool IsFlyingWithJuiceItemWayPoint => _isFlyingWithJuiceItemWayPoint;
    public FlyingWithJuiceItem FlyingWithJuiceItem => _flyingWithJuiceItem;

    public Item Item => _item;

    public GameObject LegTarget => _legTarget;
}

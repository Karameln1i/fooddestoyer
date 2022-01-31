using System.Collections;
using System.Collections.Generic;
using RayFire;
using UnityEngine;

[RequireComponent(typeof(RayfireRigid))]
public class ExplodingItem : Item
{
    [SerializeField] private RayfireBomb _bomb;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _topPoint;
    
    private RayfireRigid _rayfireRigid;

    private void Awake()
    {
        _rayfireRigid = GetComponent<RayfireRigid>();
    }
    
    protected override void Break(GameObject legPivot)
    {
        if (legPivot.transform.position.y<_topPoint.transform.localPosition.y)
        {
            Discard();
        }
        else
        {
            _bomb.Explode(0);
            _rayfireRigid.Demolish();
            _particleSystem.Play();

            Desrtoyed();
        }
    }
}

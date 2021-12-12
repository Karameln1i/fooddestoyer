using System.Collections;
using System.Collections.Generic;
using RayFire;
using UnityEngine;

[RequireComponent(typeof(RayfireRigid))]
public class ExplodingItem : Item
{
    [SerializeField] private RayfireBomb _bomb;
    [SerializeField] private ParticleSystem _particleSystem;
    
    private RayfireRigid _rayfireRigid;

    private void Awake()
    {
        _rayfireRigid = GetComponent<RayfireRigid>();
        
    }
    
    protected override void Break()
    {
       
        _bomb.Explode(0);
        _rayfireRigid.Demolish();
        _particleSystem.Play();

        Desrtoyed();
    }
}

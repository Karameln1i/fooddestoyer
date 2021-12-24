using System.Collections;
using System.Collections.Generic;
using RayFire;
using UnityEngine;

[RequireComponent(typeof(RayfireRigid))]
public class FoodSplittingIntoSeveralParts : Item
{
    private RayfireRigid _rayfireRigid;

    private void Awake()
    {
        _rayfireRigid = GetComponent<RayfireRigid>();
    }
    
    protected override void Break(GameObject LegPivot)
    {
       _rayfireRigid.Initialize();
    }
}

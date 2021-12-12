using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackingItem : Item
{
    [SerializeField] private List<Rigidbody>  _rigidbodies;
    [SerializeField] private List <ParticleSystem>  _explousions;
    
    protected override void Break()
    {
        PlayEffects();
        
        for (int i = 0; i < _rigidbodies.Capacity; i++)
        {
            _rigidbodies[i].useGravity = true;
        }

        Desrtoyed();
    }

    private void PlayEffects()
    {
        for (int i = 0; i < _explousions.Count; i++)
        {
            _explousions[i].Play();
        }
    }
}

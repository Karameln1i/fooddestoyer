using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackingItem : Item
{
    [SerializeField] private List<Rigidbody>  _rigidbodies;
    [SerializeField] private List <ParticleSystem>  _explousions;
    [SerializeField] private GameObject _topPoint;
    
    protected override void Break(GameObject legPivot)
    {
        if (legPivot.transform.position.y<_topPoint.transform.localPosition.y)
        {
            Discard();
        }
        else
        {
            PlayEffects();
        
            for (int i = 0; i < _rigidbodies.Capacity; i++)
            {
                _rigidbodies[i].useGravity = true;
            }

            Desrtoyed();
        }
        
      
    }

    private void PlayEffects()
    {
        for (int i = 0; i < _explousions.Count; i++)
        {
            _explousions[i].Play();
        }
    }
}

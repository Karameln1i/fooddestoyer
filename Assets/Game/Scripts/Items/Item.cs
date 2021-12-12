using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider),typeof(Rigidbody),typeof(ItemCollisionHandler))]
public abstract class Item : MonoBehaviour
{
    [SerializeField] private Vibrations _vibrations;
    [SerializeField] private GameObject _legTarget;

    private bool _notDestroyed;
    private BoxCollider _boxCollider;
    private float _speed;
    private Coroutine _goToDownCorutine;

    public GameObject LegTarget => _legTarget;
    
    public event UnityAction<Item> Destroyed;
    public event UnityAction<float> StrengthBroken;
    

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _notDestroyed = true;
    }

    protected virtual void Break()
    {
        
    }

    protected virtual void Flatten(float speed)
    {
        
    }

    public virtual void Deform(float speed)
    {
        
       // while (_notDestroyed)
       // { 
        //    Vibrate();
       // }
    }

    public void Desrtoyed()
     {
         Destroyed?.Invoke(this);
         _notDestroyed = false;
     }

    public void Liquidate(float speed)
    { 
      Break();
      Flatten(speed);

      /*while (_notDestroyed)
      { 
        Vibrate();
      }*/
    }

    public void TurnOnColdier()
    {
        _boxCollider.enabled = true;
    }
    
    private void Vibrate()
    {
        if (_speed==0.25f)
        {
            _vibrations.PlaySlowDestroyVibrate();
        }
        else
        {
            _vibrations.PlayFastDestroyVibrate();
        }
    }
}
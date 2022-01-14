using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Conveer))]
public class TurnConveyor : MonoBehaviour
{
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private Conveer _conveer;
   // [SerializeField] private SlowDownTime _slowDownTime;

    private bool _touchedFlyingWithJuiceItem;

   // private Conveer _conveer;

    private void Awake()
    {
        //_conveer = GetComponent<Conveer>();
    }
    
    private void OnEnable()
    {
        _playerCollisionHandler.TouchedFlyingWithJuiceItem += OnTouchedFlyingWithJuiceItem;
       // _slowDownTime.Slowed += OnTimeSlowed;
       // _slowDownTime.Resumed += OnTimeResumed;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.TouchedFlyingWithJuiceItem -= OnTouchedFlyingWithJuiceItem;
       // _slowDownTime.Slowed -= OnTimeSlowed;
       // _slowDownTime.Resumed -= OnTimeResumed;
    }
    
    private void OnTouchedFlyingWithJuiceItem(FlyingWithJuiceItem Item)
    {
        if (!Item.Disacarded)
        {
            if (!_touchedFlyingWithJuiceItem)
            {
                _conveer.enabled = false;
                Item.Exploaded += OnItemExploaded;

                _touchedFlyingWithJuiceItem = true;
            }
        }

    }

    private void OnItemExploaded(FlyingWithJuiceItem Item)
    {
        _conveer.enabled = true;
        
        _touchedFlyingWithJuiceItem = false;
    }

   /* private void OnTimeSlowed()
    {
        _conveer.enabled = false;
    }

    private void OnTimeResumed()
    {
        _conveer.enabled = true;
        Debug.Log("_conveer slowed");
    }*/
}

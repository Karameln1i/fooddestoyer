using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Conveer))]
public class TurnConveyor : MonoBehaviour
{
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private Conveer _conveer;

    private bool _touchedFlyingWithJuiceItem;

   // private Conveer _conveer;

    private void Awake()
    {
        //_conveer = GetComponent<Conveer>();
    }
    
    private void OnEnable()
    {
        _playerCollisionHandler.TouchedFlyingWithJuiceItem += OnTouchedFlyingWithJuiceItem;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.TouchedFlyingWithJuiceItem -= OnTouchedFlyingWithJuiceItem;
    }
    
    private void OnTouchedFlyingWithJuiceItem(FlyingWithJuiceItem Item)
    {
        if (!_touchedFlyingWithJuiceItem)
        {
            _conveer.enabled = false;
            Item.Exploaded+=OnItemExploaded;

            _touchedFlyingWithJuiceItem = true;
        }
      
    }

    private void OnItemExploaded(FlyingWithJuiceItem Item)
    {
        _conveer.enabled = true;
        _touchedFlyingWithJuiceItem = false;
    }
}

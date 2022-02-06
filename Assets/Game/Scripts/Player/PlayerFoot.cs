using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    [SerializeField] private ChangeTargetPosition _changeTargetPosition;
    [SerializeField] private GameObject _legPivot;

    public GameObject LegPivot => _legPivot;

    public ChangeTargetPosition GetChangeTargetPosition()
    {
        return _changeTargetPosition;
    }

    public float GetSpeedForFlatting()
    {
        return _changeTargetPosition.LegloweringSpeedForFlattening;
   
    }

    public float GetSped()
    {
        return _changeTargetPosition.LegloweringSpeed;
    }

    public bool GetСondition()
    {
        return _changeTargetPosition.IsGoDown;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<ControllPoint>(out ControllPoint controllPoint))
        {
            controllPoint.TurnOf();
        }
    }
}

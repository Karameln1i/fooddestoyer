using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    [SerializeField] private ChangeTargetPosition _changeTargetPosition;

    public ChangeTargetPosition GetChangeTargetPosition()
    {
        return _changeTargetPosition;
    }

    public float GetSpeedForFlatting()
    {
       // Debug.Log("legspeed "+ _changeTargetPosition.LegloweringSpeed);
        return _changeTargetPosition.LegloweringSpeedForFlattening;
   
    }

    public float GetSped()
    {
        return _changeTargetPosition.LegloweringSpeed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<ControllPoint>(out ControllPoint controllPoint))
        {
           // TouchedControlPoint?.Invoke(controllPoint.GetLegTarget());
            controllPoint.TurnOf();
            Debug.Log("controll point");
        }

        if (collision.TryGetComponent<Item>(out Item item))
        {
            //TouchedItem?.Invoke();
        }
    }
    
}

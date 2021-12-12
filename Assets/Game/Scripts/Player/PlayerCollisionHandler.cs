using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private ChangeTargetPosition _changeTargetPosition;

    public event UnityAction<GameObject> TouchedControlPoint;
    public event UnityAction<FlyingWithJuiceItem> TouchedFlyingWithJuiceItem;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<ControllPoint>(out ControllPoint controllPoint))
        {
            //TouchedControlPoint?.Invoke(controllPoint.GetLegTarget());
            //controllPoint.TurnOf();

            
            
        }
        
        if (collision.TryGetComponent<FlyingWithJuiceItem>(out FlyingWithJuiceItem flyingWithJuiceItem))
        {
            TouchedFlyingWithJuiceItem?.Invoke(flyingWithJuiceItem);
        }
    }
}

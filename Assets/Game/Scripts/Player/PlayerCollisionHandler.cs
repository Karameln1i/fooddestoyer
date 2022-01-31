using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private ChangeTargetPosition _changeTargetPosition;
    [SerializeField] private TurnPlayerInput _turnPlayerInput;

    public event UnityAction<GameObject> TouchedControlPoint;
    public event UnityAction<FlyingWithJuiceItem> TouchedFlyingWithJuiceItem;
    public event UnityAction TouchedFallItem;
        

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Item>(out Item item))
        {
            Debug.Log("itemmmm");
            if (item.IsDestroyed)
            {
                _turnPlayerInput.ApplyItem(item);
            }
        }
        
        if (collision.TryGetComponent<FlyingWithJuiceItem>(out FlyingWithJuiceItem flyingWithJuiceItem))
        {
            TouchedFlyingWithJuiceItem?.Invoke(flyingWithJuiceItem);
        }
    }
}

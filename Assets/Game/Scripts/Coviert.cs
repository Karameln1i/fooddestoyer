using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Coviert : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    
    private void OnTriggerStay(Collider collision)
    {
        if (collision.TryGetComponent<Item>(out Item item))
        {
            item.transform.Translate(Vector3.left*_speed*Time.deltaTime);
        }
    }
}

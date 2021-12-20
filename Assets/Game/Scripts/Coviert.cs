using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Coviert : MonoBehaviour
{
    [SerializeField] private float _speed;
    //[SerializeField] private Material _material;
    
   [SerializeField] private Rigidbody _rigidbody;

    private void Awake()
    {
       // _rigidbody = GetComponent<Rigidbody>();
    }

   

    private void OnTriggerStay(Collider collision)
    {
        if (collision.TryGetComponent<Item>(out Item item))
        {
           // Vector3 direction=
            
           item.transform.Translate(Vector3.left*_speed*Time.deltaTime);
        }
    }
}

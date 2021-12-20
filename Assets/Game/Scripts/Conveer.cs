using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveer : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = _rigidbody.position;
        _rigidbody.position += Vector3.right * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(pos);
    }
}

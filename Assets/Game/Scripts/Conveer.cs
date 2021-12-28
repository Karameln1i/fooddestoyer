using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Conveer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Material _material;
    [SerializeField] private float _mainTextureOffsetSpead;
    [SerializeField] private Animator _animator;
    
    private Rigidbody _rigidbody;
 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _animator.enabled = true;
    }
    
    private void FixedUpdate()
    {
        _material.mainTextureOffset=new Vector2(0f,-Time.time*_mainTextureOffsetSpead*Time.deltaTime);
        Vector3 pos = _rigidbody.position;
        _rigidbody.position += Vector3.right * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(pos);
    }

  
}

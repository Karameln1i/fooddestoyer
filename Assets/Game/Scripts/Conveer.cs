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
    [SerializeField] private Player _player;
    
    
    private Rigidbody _rigidbody;
 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _animator.enabled = true;
        _player.Won += OnPlayerWon;
        _player.Lost += OnPlayerLost;
    }

    private void OnDisable()
    {
        _player.Won -= OnPlayerWon;
        _player.Lost -= OnPlayerLost;
    }
    
    private void FixedUpdate()
    {
        _material.mainTextureOffset=new Vector2(0f,-Time.time*_mainTextureOffsetSpead*Time.deltaTime);
        Vector3 pos = _rigidbody.position;
        _rigidbody.position += Vector3.right * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(pos);
    }


    private void OnPlayerWon()
    {
        enabled = false;
    }

    private void OnPlayerLost()
    {
        enabled = false;
    }
}

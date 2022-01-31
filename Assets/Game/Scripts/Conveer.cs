using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Conveer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Material _material;
    [SerializeField] private float _mainTextureOffsetSpead;
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    
    
    private Rigidbody _rigidbody;
    private FlyingWithJuiceItem _flyingWithJuiceItem;
    private  float _speedAfterTheDestruction;
    private const int SpeedAfterTouching = 0;
    private float Speed;
  

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speedAfterTheDestruction = _speed;
        Speed = _speed;
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
        _material.mainTextureOffset = new Vector2(0,0);
    }
    
    private void FixedUpdate()
    {
        _material.DOOffset(new Vector2(0, -300), 2400);
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

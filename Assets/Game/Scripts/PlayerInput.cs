using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;


    
    public event UnityAction Clicked;


    private void OnEnable()
    {
        _player.Won += OnPlayerWon;
    }

    private void OnDisable()
    {
        _player.Won -= OnPlayerWon;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked?.Invoke();
        }
    }

    private void OnPlayerWon()
    {
        enabled = false;
    }
}

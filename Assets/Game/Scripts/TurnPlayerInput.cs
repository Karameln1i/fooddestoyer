using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    public void ApplyItem(Item item)
    {
        _playerInput.enabled = false;
        item.Destroyed += OmItemDestroyed;
    }

    private void OmItemDestroyed(Item item)
    {
        _playerInput.enabled = true;
        item.Destroyed -= OmItemDestroyed;
        
    }
}

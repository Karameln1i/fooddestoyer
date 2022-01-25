using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
     [SerializeField] private Player _player;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerFoot>(out PlayerFoot playerFoot))
        {
        _player.Win();
        }
    }
}


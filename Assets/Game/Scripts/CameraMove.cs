using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private DestroyState _destroyState;
    [SerializeField]  private float _speed;

    private void OnEnable()
    {
        _destroyState.Launched += OnStateLaunched;
        _destroyState.Disabled += OnStateDisabled;
    }

    private void Update()
    {
        transform.Translate(new Vector3(1,0,0)*_speed*Time.deltaTime);
    }

    private void OnStateLaunched()
    {
        enabled = false;
        _destroyState.Launched -= OnStateLaunched;
    }

    private void OnStateDisabled()
    {
        enabled = true;
        _destroyState.Disabled -= OnStateDisabled;
    }
    
}

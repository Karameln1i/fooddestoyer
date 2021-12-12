using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class DistanceTransition : Transition
{
    [SerializeField] private MoveState _moveState;
    [SerializeField] private DestroyTransition _destroyTransition;

    public event UnityAction Launched;

    private void OnEnable()
    {
        Launched?.Invoke();
        _moveState.ControlPointReached += OnControlPointReached;
        _destroyTransition.Launched += OnDestroyTransitionLaunched;

    }

    private void OnDestroyTransitionLaunched()
    {
        _destroyTransition.Launched -= OnDestroyTransitionLaunched;
        NeedTransit = false;
    }

    private void OnControlPointReached()
    {
        _moveState.ControlPointReached -= OnControlPointReached;
        Debug.Log("needTransit");
        NeedTransit = true;
    }
}
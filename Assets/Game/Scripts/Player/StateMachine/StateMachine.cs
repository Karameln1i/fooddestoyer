using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private List<State> _allStates;
    
    private State _currentState;
    private Transform _transform;

    private void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState!=null)
        {
            Transit(nextState);
        }
    }
   
    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState!=null)
        {
            _currentState.Enter();
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState!=null)
        {
            _currentState.Exit();

            _currentState = nextState;

            if (_currentState!=null)
            {
                _currentState.Enter();
            }
        }
    }
    
    public void Off()
    {
        for (int i = 0; i < _allStates.Capacity; i++)
        {
            _allStates[i].enabled = false;
        }

        enabled = false;
    }
}

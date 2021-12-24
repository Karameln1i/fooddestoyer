using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Menu menu;
    
    //private Animator _animator;

    public event UnityAction Won;
    public event UnityAction Lost;
    
    private void Awake()
    {
        //_animator = GetComponent<Animator>();
    }

    /*private void OnEnable()
    {
        _finish.LevelComplited += OnLevelComplited;
    }

  /*  private void OnDisable()
    {
        _finish.LevelComplited -= OnLevelComplited;
    }*/

    public void Win()
    {
        Won?.Invoke();
 
        Debug.Log("проигрыл");
    }

    public void Lose()
    {
        Lost?.Invoke();
    }
}

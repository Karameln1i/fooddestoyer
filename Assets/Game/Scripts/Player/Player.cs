using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Menu menu;
    [SerializeField] private FinishItem _finishItem;
    
    //private Animator _animator;

    public event UnityAction Won;
    public event UnityAction Lost;
    
    private void Awake()
    {
        //_animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _finishItem.Destoryed += OnFinisItemDestroyed;
    }

   private void OnDisable()
    {
        _finishItem.Destoryed -= OnFinisItemDestroyed;
    }

   private void OnFinisItemDestroyed()
    {
        Won?.Invoke();
 
        Debug.Log("проигрыл");
    }

    public void Lose()
    {
        Lost?.Invoke();
    }
}

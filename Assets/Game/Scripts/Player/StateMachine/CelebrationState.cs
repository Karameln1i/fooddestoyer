using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(DestroyTransition))]
public class CelebrationState : MonoBehaviour
{
    private Animator _animator;
    private DestroyTransition _destroyTransition;

    [SerializeField] private Item _finishItem;
    
    private void Awake()
    {
        _destroyTransition = GetComponent<DestroyTransition>();
    }

    private void OnEnbale()
    {
        //_destroyTransition.FinishItemDestriyed += OnFinisItemDestroyed;
        _finishItem.Destroyed += OnFinisItemDestroyed;
    }

    private void OnDisable()
    {
        //_destroyTransition.FinishItemDestriyed -= OnFinisItemDestroyed;
    }

    private void OnFinisItemDestroyed(Item item)
    {
        Debug.Log("Dancing");
        _animator.Play("Catwalk Walking@Snake Hip Hop Dance");
    }
}

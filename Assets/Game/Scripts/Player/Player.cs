using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Menu menu;
    [SerializeField] private FinishItem _finishItem;

    public event UnityAction Won;
    public event UnityAction Lost;

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

    }

   public void Win()
   {
       Won?.Invoke();
   }
   
    public void Lose()
    {
        Lost?.Invoke();
    }
}

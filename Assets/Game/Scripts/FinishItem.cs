using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishItem : MonoBehaviour
{
    [SerializeField] private Item _item;
    
    public event UnityAction LevelComplited;

    private void OnEnable()
    {
        _item.Destroyed += OnItemDestroyed;
    }

    private void OnDisable()
    {
        _item.Destroyed -= OnItemDestroyed;
    }

    private void OnItemDestroyed(Item item)
    {
        LevelComplited?.Invoke();
    }

}

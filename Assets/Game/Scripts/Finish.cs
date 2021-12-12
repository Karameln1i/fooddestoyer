using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private FinishItem _finishItem;
    [SerializeField] private Menu _menu;
    [SerializeField] private Animator _playerAnimator;

    public event UnityAction LevelComplited;

    private void OnEnable()
    {
        _finishItem.LevelComplited += OnLevelComplited;
    }

    private void OnDisable()
    {
        _finishItem.LevelComplited -= OnLevelComplited;
    }

    private void OnLevelComplited()
    {
        LevelComplited?.Invoke();
    }
}

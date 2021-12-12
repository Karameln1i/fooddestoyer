using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Scale:MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ScaleValueChecker _scaleValueChecker;
    [SerializeField] private float _time;
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private Tween _tween;
    
    private void OnEnable()
    {
       _tween= _slider.DOValue(_slider.maxValue, _time).SetLoops(-1, LoopType.Yoyo);
       _playerInput.Clicked += OnPlayerClicked;
       _player.Lost += OnPlayerLost;
       _player.Won += OnPlayerWon;
    }

    private void OnDisable()
    {
        _slider.value = _slider.minValue;
    }

    private void OnPlayerClicked()
    {
        _playerInput.Clicked -= OnPlayerClicked;
        _tween.Kill();
        _scaleValueChecker.ApplyValue(_slider.value);
    }

    private void OnPlayerLost()
    {
        _player.Lost -= OnPlayerLost;
        TurnOf();
    }

    private void OnPlayerWon()
    {
        _player.Won -= OnPlayerWon;
        TurnOf();
    }
    
    public float GetValue()
    {
        return _slider.value;
    }

    public void TurnOn()
    {
       // gameObject.SetActive(true);
    }

    public void TurnOf()
    {
       // gameObject.SetActive(false);
    }
    
    
}
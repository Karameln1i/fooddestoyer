using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private int _levelIndex;
    [SerializeField] private LevelComplitedPanel _levelComplitedPanel;
    //[SerializeField] private Button _restartButton;
  
    private const string LastComplitedLevel = nameof(LastComplitedLevel);
    
    public int LevelIndex => _levelIndex;

    public event UnityAction <int> LevelStarted;
    public event UnityAction<int> LevelCompleted; 
   // public event UnityAction <int> LevelRestartetd;
   // public event UnityAction<int> LevelFailed;
  
 
    public int lastComplitedLevel
    {
        get { return PlayerPrefs.GetInt(LastComplitedLevel, 0); }
       private set { PlayerPrefs.SetInt(LastComplitedLevel, value); }
    }
    
    private void OnEnable()
    {
        _levelComplitedPanel.Opened += OnLevelCompletedPanelOpened;
    }

    private void OnDisable()
    {
        _levelComplitedPanel.Opened -= OnLevelCompletedPanelOpened;
    }
  
    private void Start()
    {
        LevelStarted?.Invoke(_levelIndex);
    }

    private void OnRestartButtonClicked()
    {
       // LevelRestartetd?.Invoke(_levelIndex);
    }
  
    private void OnLevelCompletedPanelOpened()
    {
        LevelCompleted?.Invoke(_levelIndex);
        lastComplitedLevel = _levelIndex;


    }
}
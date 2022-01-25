using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    
    [SerializeField] private LevelComplitedPanel _levelComplitedPanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private LevelIndex _levelIndex;
    [SerializeField] private Player _player;
    [SerializeField] private FallItem _fallItem;

    [SerializeField] private LevelPassedPanel _levelPassedPanel;
    //[SerializeField] private Button _restartButton;
  
    private int _slevelIndex;
    
    private const string LastComplitedLevel = nameof(LastComplitedLevel);
    
    public int LevelIndex => _slevelIndex;

    public event UnityAction <int> LevelStarted;
    public event UnityAction<int> LevelCompleted; 
    public event UnityAction <int> LevelRestartetd;
   public event UnityAction<int> LevelFailed;


   private void Awake()
   {
       _slevelIndex = _levelIndex.GetValue();
   }
   
    public int lastComplitedLevel
    {
        get { return PlayerPrefs.GetInt(LastComplitedLevel, 0); }
       private set { PlayerPrefs.SetInt(LastComplitedLevel, value); }
    }
    
    private void OnEnable()
    {
        _levelComplitedPanel.Opened += OnLevelCompletedPanelOpened;
        _levelPassedPanel.Opened += OnOpenedPanelOpened;
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnDisable()
    {
        _levelComplitedPanel.Opened -= OnLevelCompletedPanelOpened;
        _levelPassedPanel.Opened -= OnOpenedPanelOpened;
        _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }
  
    private void Start()
    {
        LevelStarted?.Invoke(_slevelIndex);
    }

    private void OnRestartButtonClicked()
    {
        LevelRestartetd?.Invoke(_slevelIndex);
    }
  
    private void OnLevelCompletedPanelOpened()
    {
        LevelCompleted?.Invoke(_slevelIndex);
        lastComplitedLevel = _slevelIndex;
    }

    private void OnOpenedPanelOpened()
    {
        LevelFailed?.Invoke(_slevelIndex);
    }
}
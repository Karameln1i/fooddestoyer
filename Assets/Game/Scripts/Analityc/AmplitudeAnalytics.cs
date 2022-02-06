using System;
using System.Collections.Generic;
using UnityEngine;

public class AmplitudeAnalytics : MonoBehaviour
{
   
    
    [SerializeField] private Level _level;
    [SerializeField] private bool _isLaunched=false;
    [SerializeField] private PlayerInput _playerInput;

    private const string SAVED_REG_DAY = "RegDay";
    private const string SAVED_REG_DAY_FULL = "RegDayFull";
    private const string SAVED_SESSION_ID = "SessionID";
    private const string IsLaunchedKey = nameof(IsLaunchedKey);
    
    private float _spentTime;
    private string _regDay
    {
        get { return PlayerPrefs.GetString(SAVED_REG_DAY, DateTime.Today.ToString("dd/MM/yy")); }
        set { PlayerPrefs.SetString(SAVED_REG_DAY, value); }
    }

    private string _regDayFull //в моем случае если вычислять daysAfter от _regDay, то итоговый параметр почему-то не доходил до Amplitude...
    {
        get { return PlayerPrefs.GetString(SAVED_REG_DAY_FULL, DateTime.Today.ToString()); }
        set { PlayerPrefs.SetString(SAVED_REG_DAY_FULL, value); }
    }

    private int _sessionID
    {
        get { return PlayerPrefs.GetInt(SAVED_SESSION_ID, 0); }
        set { PlayerPrefs.SetInt(SAVED_SESSION_ID, value); }
    }

    private void Awake()
    {
        Amplitude amplitude = Amplitude.Instance;
        amplitude.logging = true;
        amplitude.init("be8c1dba53f744667dbe49d285b6cf87");
        GameStart();
    }
    
    private void OnEnable()
    {
        _playerInput.Clicked += OnPlayerFirstGroveClicked;
        _level.LevelStarted += OnLevelStarted;
        _level.LevelCompleted += OnLevelCompleted;
        _level.LevelFailed += OnLevelFailed;
        _level.LevelRestartetd += OnlevelRestarted;
    }

    private void OnDisable()
    {
        _level.LevelStarted -= OnLevelStarted;
        _level.LevelCompleted -= OnLevelCompleted;
        _level.LevelFailed -= OnLevelFailed;
        _level.LevelRestartetd -= OnlevelRestarted;
    }

    private void Update()
    {
        _spentTime += Time.deltaTime;
    }
    
    private void GameStart()
    {
        if (_level.IsBootScene)
        {
            if (_sessionID==0)
            {
                _regDay = DateTime.Today.ToString("dd/MM/yy");
                Debug.Log("first launch");
            }

            SetStartedProperties();
            FireEvent("game_start",_sessionID);
        }
    }

    private void SetStartedProperties()
    {
        _sessionID = _sessionID + 1;
        //Amplitude.Instance.setUserProperty("session_count", _sessionID);

       // int daysAfter = DateTime.Today.Subtract(DateTime.Parse(_regDayFull)).Days;
        //Amplitude.Instance.setUserProperty("days_after", daysAfter);
    }
    

    private void OnLevelStarted(int LevelIndex) => FireEvent("level_start",LevelIndex);

    private void OnLevelCompleted(int LevelIndex) => FireEvent("level_complited",LevelIndex,Convert.ToInt32(_spentTime));

    private void OnLevelFailed(int LevelIndex) => FireEvent("fail",LevelIndex,Convert.ToInt32(_spentTime));
    
    private void OnlevelRestarted(int LevelIndex) => FireEvent("restart",LevelIndex);

    private void FireEvent(string eventName, int value)
    {
        SettingUserProperties();
        Dictionary<string, object> eventProps = new Dictionary<string, object>();
        eventProps.Add(eventName, value);
        Amplitude.Instance.logEvent(eventName, eventProps);
    }

    private void FireEvent (string eventName,int value1,int value2)
    {
        SettingUserProperties();
        Dictionary<string, object> values = new Dictionary<string, object>();
        values.Add(Convert.ToString(value1), value2);
        Amplitude.Instance.logEvent(eventName, values);
    }
    
   

    private void SettingUserProperties()
    {
        int lastLevel = _level.lastComplitedLevel;
        
        Amplitude.Instance.setUserProperty("level_last", lastLevel);
        
        Amplitude.Instance.setUserProperty("session_count", _sessionID);
        
        Amplitude.Instance.setUserProperty("reg_day", _regDay);
        
        var parsedDate = DateTime.Parse(_regDay);
        var days_in_game = DateTime.Today.Subtract(parsedDate).Days;
        
        Amplitude.Instance.setUserProperty("days_in_game", days_in_game);
        
        
        
        //Amplitude.Instance.setUserProperty("days_game", Convert.ToDateTime(_regDay));
    }

    private void OnPlayerFirstGroveClicked()
    {
        _spentTime = 0;
        _playerInput.Clicked -= OnPlayerFirstGroveClicked;
    }
}
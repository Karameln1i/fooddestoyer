using System;
using System.Collections.Generic;
using UnityEngine;

public class sd : MonoBehaviour
{
    private const string SAVED_REG_DAY = "RegDay";
    private const string SAVED_REG_DAY_FULL = "RegDayFull";
    private const string SAVED_SESSION_ID = "SessionID";
    private const string IsLaunchedKey = nameof(IsLaunchedKey);
    private const string LastComplitedLevel = nameof(LastComplitedLevel);
    
    private float _spentTime;
    
    [SerializeField] private Level _level;
    [SerializeField] private bool _isLaunched=false;
    private string _regDay
    {
        get { return PlayerPrefs.GetString(SAVED_REG_DAY, DateTime.Today.ToString("dd/MM/yyyy")); }
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
    
    private int _lastComplitedLevel
    {
        get { return PlayerPrefs.GetInt(LastComplitedLevel, 0); }
        set { PlayerPrefs.SetInt(LastComplitedLevel, value); }
    }


    private void Awake()
    {
        Debug.Log(_lastComplitedLevel);
        Amplitude amplitude = Amplitude.Instance;
        amplitude.logging = true;
        amplitude.init("be8c1dba53f744667dbe49d285b6cf87");
        
        GameStart();
    }
    
    private void OnEnable()
    {
        _level.LevelStarted += OnLevelStarted;
        _level.LevelCompleted += OnLevelCompleted;
        //_level.LevelFailed += OnLevelFailed;
        //_level.LevelRestartetd += OnlevelRestarted;
    }

    private void OnDisable()
    {
        _level.LevelStarted -= OnLevelStarted;
        _level.LevelCompleted -= OnLevelCompleted;
       // _level.LevelFailed -= OnLevelFailed;
       // _level.LevelRestartetd -= OnlevelRestarted;
    }

    private void Update()
    {
        _spentTime += Time.deltaTime;
    }
    
    private void GameStart()
    {
        if (_level.LevelIndex == 0)
        {
            if (_sessionID==0)
            {
                _regDay = DateTime.Today.ToString("dd/MM/yy");
            }

            SetStartedProperties();
            FireEvent("game_start",_sessionID);
        }
  
        
    }
    
    
    private void SetStartedProperties()
    {
        _sessionID = _sessionID + 1;

        // int daysAfter = DateTime.Today.Subtract(DateTime.Parse(_regDayFull)).Days;
        //Amplitude.Instance.setUserProperty("days_after", daysAfter);
    }
    

    private void OnLevelStarted(int LevelIndex) => FireEvent("level_start",LevelIndex);

    private void OnLevelCompleted(int LevelIndex)
    {
        _lastComplitedLevel = LevelIndex;
        FireEvent("level_complite", LevelIndex, Convert.ToInt32(_spentTime));
    }

    private void OnLevelFailed(int LevelIndex) => FireEvent("level_fail",LevelIndex,Convert.ToInt32(_spentTime));
    
    private void OnlevelRestarted(int LevelIndex) => FireEvent("restart",LevelIndex);

    private void FireEvent(string eventName, int value)
    {
        SettingUserProperties();
        Dictionary<string, object> eventProps = new Dictionary<string, object>();
        eventProps.Add(eventName, value);
        Amplitude.Instance.logEvent(eventName, eventProps);
    }
    
    private void FireEvent(string eventName, string value)
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
        int lastComplitedLevel = _lastComplitedLevel;

        FireEvent("level_last", lastComplitedLevel);
        FireEvent("session_count", _sessionID);
        FireEvent("reg_day", _regDay);

        var parsedDate = DateTime.Parse(_regDay);
        var days_in_game = DateTime.Today.Subtract(parsedDate).Days;
        
        FireEvent("days_in_game", days_in_game);
        
        Amplitude.Instance.setUserProperty("session_count", _sessionID);
        
        Amplitude.Instance.setUserProperty("reg_day", _regDay);
        
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class NextLevel 
{
    [SerializeField] private SceneReference _nextLevel;
    [SerializeField] private int _levelIndex;

    private const string LastPassedLevelKey = nameof(LastPassedLevelKey);
    

    public void ChangeLevel(int index)
    {
        _levelIndex = index;
    }

    public bool IsEmpety()
    {
        if (_levelIndex==null)
        {
            return true;
        }

        return false;
    }
    
    public static NextLevel Load()
    {
        if (PlayerPrefs.HasKey(LastPassedLevelKey) == false)
            return new NextLevel();

        var jsonString = PlayerPrefs.GetString(LastPassedLevelKey);
        return JsonUtility.FromJson<NextLevel>(jsonString);
    }

    public void LoadLastLevel()
    {
        SceneManager.LoadScene(_levelIndex);
    }

    public void Save()
    {
        var jsonString = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(LastPassedLevelKey,jsonString);
    }
}
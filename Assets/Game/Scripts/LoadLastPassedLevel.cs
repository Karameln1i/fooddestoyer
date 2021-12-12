using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLastPassedLevel : MonoBehaviour
{
    [SerializeField] private bool _isFirstLaunch=true;
    [SerializeField] private SceneReference _sceneReference;
    [SerializeField] private NextLevel _level;

    private const string IsLaunchedKey = nameof(IsLaunchedKey);
    
    private void Awake()
    {

        NextLevel nextLevel = NextLevel.Load();

        if (Load())
        {
            _isFirstLaunch = false;
            Save();
            SceneManager.LoadScene(_sceneReference);
        }
        else
        {
            nextLevel.LoadLastLevel();
        }
        
    }
    
    private  bool Load()
    {
        if (PlayerPrefs.HasKey(IsLaunchedKey) == false)
        {
            return true;
        }
        
        var jsonString = PlayerPrefs.GetString(IsLaunchedKey);
        return JsonUtility.FromJson<bool>(jsonString);
    }

    private void Save()
    {
        var jsonString = JsonUtility.ToJson(_isFirstLaunch);
        PlayerPrefs.SetString(IsLaunchedKey, jsonString);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIndex : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _nextLevelButton;
    
    private const string Level_Index = "Level_Index";
    
    private int _levelIndex
    {
        get { return PlayerPrefs.GetInt(Level_Index, 1); }
        set { PlayerPrefs.SetInt(Level_Index, value); }
    }

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnPlayerClickedToButton);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnPlayerClickedToButton);
    }

    private void OnPlayerClickedToButton()
    {
        _levelIndex += 1;
    }
    
    public int GetValue()
    {
        return _levelIndex;
    }
}

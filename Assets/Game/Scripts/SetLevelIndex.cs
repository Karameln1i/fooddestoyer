using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelIndex : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private LevelIndex _levelIndex;
    [SerializeField] private bool _isLevelNumber;

    private void Awake()
    {
        if (_isLevelNumber)
        {
            _text.text +="Level " +_levelIndex.GetValue().ToString();
        }
        else
        {
            _text.text=_levelIndex.GetValue().ToString();
        }
      
    }

}

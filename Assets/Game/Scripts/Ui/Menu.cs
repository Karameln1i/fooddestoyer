using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   [SerializeField] private Player _player;
   [SerializeField] private LevelComplitedPanel _levelComplitedPanel;
   // [SerializeField] private Finish finish;
    [SerializeField] private float _targetImageColor;
    [SerializeField] private float _interpalation;

    private const float dellay = 1f;
    
    private void OnEnable()
    {
       // _player.Lost+= OnPlayerLose;
        //finish.LevelComplited += OnLevelComplited;
        _player.Won += OnPlayerWon;
    }

    private void OnDisable()
    {
        _player.Won -= OnPlayerWon;
    }

    /*private void OnPlayerLose()
    {
        StartCoroutine(OpenPaneLevelPassedPanel(_levelPassedPanel));
        _player.Lost-= OnPlayerLose;
    }

    private void OnLevelComplited()
    {
        StartCoroutine(OpenPaneLevelPassedPanel(_levelComplitedPanel));
        finish.LevelComplited -= OnLevelComplited;
    }*/
    
    private IEnumerator DarkenScreen(LevelComplitedPanel panel)
    {
        var color = panel.GetComponent<Image>().color;

        while (color.a!=_targetImageColor)
        {
            color.a = Mathf.Lerp(color.a, _targetImageColor, _interpalation*Time.deltaTime);
            panel.GetComponent<Image>().color = color;
            yield return null;
            
        }
    }
    
  

  private void OnPlayerWon()
  {
      _levelComplitedPanel.gameObject.SetActive(true);
      StartCoroutine(DarkenScreen(_levelComplitedPanel));
  }
}
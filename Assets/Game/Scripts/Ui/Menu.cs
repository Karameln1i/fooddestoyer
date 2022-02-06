using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   [SerializeField] private Player _player;
   [SerializeField] private LevelComplitedPanel _levelComplitedPanel;
   [SerializeField] private FinishItem _finishItem;
   [SerializeField] private GameObject _progressBar;
   [SerializeField] private GameObject _levelPassedPanel;
   [SerializeField] private float _targetImageColor;
    [SerializeField] private float _interpalation;

    private const float dellay = 1f;
    
    private void OnEnable()
    {
        _player.Lost+= OnPlayerLose;
        _player.Won += OnPlayerWon;
    }

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

    private IEnumerator OpenPanel(GameObject panel)
    {
        yield return new WaitForSeconds(dellay);
        _levelPassedPanel.SetActive(true);
        _progressBar.SetActive(false);
    }

  private void OnPlayerWon()
  {
      _levelComplitedPanel.gameObject.SetActive(true);
      StartCoroutine(DarkenScreen(_levelComplitedPanel));
      _progressBar.SetActive(false);
      _player.Won -= OnPlayerWon;
  }
  
  private void OnPlayerLose()
  {
      StartCoroutine(OpenPanel(_levelPassedPanel));
      _player.Lost-= OnPlayerLose;
  }
}
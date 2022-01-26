using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Training : MonoBehaviour
{
    [SerializeField] private TurnConveyor _turnConveyor;
    [SerializeField] private TextMeshProUGUI _text;
    
    
    private int _clickCount;
    private StopTimeWayPoint _stopTimeWayPoint;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<StopTimeWayPoint>(out StopTimeWayPoint stopTimeWayPoint))
        {
            StopTime();
            ChangeText(stopTimeWayPoint.Text);
            _stopTimeWayPoint=stopTimeWayPoint;
            StartCoroutine(CheckClick());
        }
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void ChangeText(string text)
    {
        _text.text = text;
    }

    private IEnumerator CheckClick()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        Time.timeScale = 1;
        _text.text = null;
      _stopTimeWayPoint.gameObject.SetActive(false);
    }
}

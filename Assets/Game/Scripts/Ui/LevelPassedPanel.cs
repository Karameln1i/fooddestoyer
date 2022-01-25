using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelPassedPanel : MonoBehaviour
{
    public event UnityAction Opened;

    private void OnEnable()
    {
        Opened?.Invoke();
    }
}

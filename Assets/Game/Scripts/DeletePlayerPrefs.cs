using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletePlayerPrefs : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(Delete);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Delete);
    }

    private void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}

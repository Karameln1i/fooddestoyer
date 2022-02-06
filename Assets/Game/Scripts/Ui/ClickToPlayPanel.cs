using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToPlayPanel : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Conveer _conveer;
    [SerializeField] private GameObject _progressBar;

    public void OnPointerClick(PointerEventData eventData)
    {
       _conveer.enabled = true;
       _progressBar.SetActive(true);
       gameObject.SetActive(false);
    }
}

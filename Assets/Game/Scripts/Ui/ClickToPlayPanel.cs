using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToPlayPanel : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Conveer _conveer;

    public void OnPointerClick(PointerEventData eventData)
    {
       _conveer.enabled = true;
       gameObject.SetActive(false);
    }
}

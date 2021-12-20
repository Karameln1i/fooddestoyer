using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToPlayPanel : MonoBehaviour,IPointerClickHandler
{
    //[SerializeField] private StateMachine _stateMachine;

    public void OnPointerClick(PointerEventData eventData)
    {
       // _stateMachine.enabled = true;
        gameObject.SetActive(false);
    }
}

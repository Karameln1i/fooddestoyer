using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPoint : MonoBehaviour
{
    [SerializeField] private GameObject _legTarget;
    [SerializeField] private Item _item;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerFoot>(out PlayerFoot playerFoot))
        {
            //_item.TurnOnColdier();
            //Debug.Log("player");

        }
    }
    
    public GameObject GetLegTarget()
    {
        return _legTarget; 
    }

    public void TurnOf()
    {
        gameObject.SetActive(false);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.localPosition;
    }
    
    public void ResetPosition()
    {
        transform.localPosition=new Vector3(_startPosition.x,_startPosition.y,0);
    }
}

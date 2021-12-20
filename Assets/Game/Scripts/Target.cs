using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Vector3 _startPosition;

    public Vector3 StartPosition => _startPosition;

    private void Awake()
    {
        _startPosition = transform.localPosition;
    }
    
    public void ResetPosition()
    {
        transform.localPosition=_startPosition;
    }
}

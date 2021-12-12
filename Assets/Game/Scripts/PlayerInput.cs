using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked?.Invoke();
        }
    }
}

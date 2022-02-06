using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOff : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.SetActive(false);
    }
}

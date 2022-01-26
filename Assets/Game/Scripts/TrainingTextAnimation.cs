using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TrainingTextAnimation : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.DORotate(new Vector3(-0.1f, -.335f, -16.629f), 23).SetLoops(0,LoopType.Yoyo);
    }
}

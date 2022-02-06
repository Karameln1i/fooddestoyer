using System.Collections;
using System.Collections.Generic;
using RayFire;
using UnityEngine;
using UnityEngine.Events;

public class SlowDownTime : MonoBehaviour
{
    [SerializeField] private List<FlyingWithJuiceItem> _flyingWithJuiceItems;
    
    [SerializeField] private float _slowMotionDuration;
    [SerializeField] private AnimationCurve _slowMotionCurve;
    [SerializeField] private  float FixedDeltaTimeMultiplier;

    private Time _startFixedDeltaTime;
    
    private void OnEnable()
    {
        for (int i = 0; i < _flyingWithJuiceItems.Capacity; i++)
        {
            _flyingWithJuiceItems[i].Destroyed += OnDestroyed;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _flyingWithJuiceItems.Capacity; i++)
        {
            _flyingWithJuiceItems[i].Destroyed -= OnDestroyed;
        }
    }

    private void OnDestroyed()
    {
        StartCoroutine(ShowSlowMotion());
    }

    private IEnumerator ShowSlowMotion()
    {
        float elapsedTime = 0;

        while (elapsedTime < _slowMotionDuration)
        {
            elapsedTime += Time.deltaTime;
            Time.timeScale = _slowMotionCurve.Evaluate(elapsedTime / _slowMotionDuration);
            Time.fixedDeltaTime =Time.timeScale* FixedDeltaTimeMultiplier;
            yield return null;
        }
      Time.timeScale = 1;
    }
}

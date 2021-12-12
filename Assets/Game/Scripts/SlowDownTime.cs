using System.Collections;
using System.Collections.Generic;
using RayFire;
using UnityEngine;

public class SlowDownTime : MonoBehaviour
{
    [SerializeField] private float _timeScaleValue;
    [SerializeField] private List<RayfireBomb> _bombs;
    
    [SerializeField] private float _slowMotionDuration;
    [SerializeField] private AnimationCurve _slowMotionCurve;
    private const float FixedDeltaTimeMultiplier = 0.02f;

    private void OnEnable()
    {
        for (int i = 0; i < _bombs.Capacity; i++)
        {
            _bombs[i].Exploded += OnExploded;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _bombs.Capacity; i++)
        {
            _bombs[i].Exploded -= OnExploded;
        }
    }

    private void OnExploded()
    {
        //Time.timeScale = _timeScaleValue;
        //Time.fixedDeltaTime = Time.timeScale * _timeScaleValue;

        StartCoroutine(ShowSlowMotion());
    }

    void Update()
    {
       // Time.timeScale = _timeScaleValue;
        //Time.fixedDeltaTime = Time.timeScale * _timeScaleValue*2;
    }
    
    private IEnumerator ShowSlowMotion()
    {
        float elapsedTime = 0;

        while (elapsedTime < _slowMotionDuration)
        {
            elapsedTime += Time.deltaTime;
            Time.timeScale = _slowMotionCurve.Evaluate(elapsedTime / _slowMotionDuration);
            Time.fixedDeltaTime = Time.timeScale * FixedDeltaTimeMultiplier;
            yield return null;
        }
        Time.timeScale = 1;
    }
}

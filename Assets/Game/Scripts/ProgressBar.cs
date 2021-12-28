using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private FinishItem _finishItem;
    [SerializeField] private Player _player;
    
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = Vector3.Distance(_player.transform.position, _finishItem.transform.position);
    }

    private void OnEnable()
    {
        _finishItem.Destoryed += OnItemDestroyed;
    }

    private void OnDisable()
    {
        _finishItem.Destoryed -= OnItemDestroyed;
    }
    
    private void Update()
    {
        Debug.Log("poc");
        _slider.value =_slider.maxValue- Vector3.Distance(_player.transform.position, _finishItem.transform.position);
    }

    private void OnItemDestroyed()
    {
        Stop();
    }
    
    private void Stop()
    {
        enabled = false;
    }
}

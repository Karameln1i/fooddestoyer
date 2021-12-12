using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirtyTheScreen : MonoBehaviour
{
    [SerializeField] private List<FlyingWithJuiceItem> _flyingWithJuiceItems;
    [SerializeField] private List<Image> _dirtyScreans;

    private void OnEnable()
    {
        for (int i = 0; i < _flyingWithJuiceItems.Capacity; i++)
        {
            _flyingWithJuiceItems[i].Exploaded += OnExploaded;
        }   
    }

    private void OnDisable()
    {
        for (int i = 0; i < _flyingWithJuiceItems.Capacity; i++)
        {
            _flyingWithJuiceItems[i].Exploaded -= OnExploaded;
        }   
    }

    private void OnExploaded(Color explosionColor)
    {
        Image dirtyScreen =_dirtyScreans[Random.Range(0, _dirtyScreans.Capacity)];
        dirtyScreen.gameObject.SetActive(true);
        dirtyScreen.color = explosionColor;
    }
    
}

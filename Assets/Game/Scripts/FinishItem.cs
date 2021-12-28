using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishItem : Item
{
    [SerializeField] private List<Rigidbody> _rigidbodies;
    [SerializeField] private List<BoxCollider> _colliders;
    [SerializeField] private GameObject _sliced;
    [SerializeField] private MeshRenderer _whole;

    public event UnityAction Destoryed;
    
    protected override void Flatten(float speed, GameObject legPivot)
    {
        _sliced.SetActive(true);
        _whole.enabled = false;
        Destoryed?.Invoke();
    }

    public event UnityAction LevelComplited;

   

  
    
    private void OnItemDestroyed(Item item)
    {
        LevelComplited?.Invoke();
    }

}

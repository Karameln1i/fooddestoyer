using System.Collections;
using System.Collections.Generic;
using RayFire;
using UnityEngine;
using UnityEngine.Events;

public class FinishItem : Item
{
    [SerializeField] private List<Rigidbody> _rigidbodies;
    [SerializeField] private List<BoxCollider> _colliders;
    [SerializeField] private GameObject _sliced;
    [SerializeField] private MeshRenderer _whole;
    [SerializeField] private RayfireBomb _bomb;
    [SerializeField] private float _bombDellay;

    public event UnityAction Destoryed;
    
    protected override void Flatten(float speed, GameObject legPivot,bool IsGoDown)
    {
        _sliced.SetActive(true);
            _whole.enabled = false;
            _bomb.Explode(_bombDellay);
        
        Destoryed?.Invoke();
    }

    public event UnityAction LevelComplited;

   

  
    
    private void OnItemDestroyed(Item item)
    {
        LevelComplited?.Invoke();
    }

}

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
   // [SerializeField] private GameObject _topPoint;

    public event UnityAction Destoryed;
    
    protected override void Flatten(float speed, GameObject legPivot)
    {
        if (legPivot.transform.position.y<TopPoint.transform.localPosition.y)
        {
            Discard();
            Debug.Log("отлетел");
        }
        else
        {
            _sliced.SetActive(true);
            _whole.enabled = false;
        }
        Destoryed?.Invoke();
    }

    public event UnityAction LevelComplited;

   

  
    
    private void OnItemDestroyed(Item item)
    {
        LevelComplited?.Invoke();
    }

}

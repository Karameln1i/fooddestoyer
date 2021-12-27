
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider),typeof(Rigidbody),typeof(ItemCollisionHandler))]
public abstract class Item : MonoBehaviour
{
    [SerializeField] private Vibrations _vibrations;
    [SerializeField] private GameObject _legTarget;
    [SerializeField] private GameObject _topPoint;
    [SerializeField]  private Rigidbody _rigidbody;
    [SerializeField] private BoxCollider _collider;
    
    private bool _notDestroyed;
    private BoxCollider _boxCollider;
    private float _speed;
    private Coroutine _goToDownCorutine;


    protected GameObject TopPoint => _topPoint;

    public GameObject LegTarget => _legTarget;
    
    public event UnityAction<Item> Destroyed;


    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _notDestroyed = true;
        //_rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Break(GameObject legPivot)
    {
        
    }

    protected virtual void Flatten(float speed,GameObject legPivot)
    {
        
    }

    public virtual void Deform(float speed,GameObject legPivot)
    {
        
       // while (_notDestroyed)
       // { 
        //    Vibrate();
       // }
    }

    public void Desrtoyed()
     {
         Destroyed?.Invoke(this);
         _notDestroyed = false;
     }

    public void Liquidate(float speed,GameObject legPivot)
    { 
      Break(legPivot);
      Flatten(speed,legPivot);

      /*while (_notDestroyed)
      { 
        Vibrate();
      }*/
    }

    public void TurnOnColdier()
    {
        _boxCollider.enabled = true;
    }
    
    private void Vibrate()
    {
        if (_speed==0.25f)
        {
            _vibrations.PlaySlowDestroyVibrate();
        }
        else
        {
            _vibrations.PlayFastDestroyVibrate();
        }
    }
    
    protected void Discard()
    {
        _rigidbody.AddForce(Vector3.up*70);
        _rigidbody.AddForce(Vector3.right*70);

        var directionIndex = Random.Range(1, 3);
        
        switch (directionIndex)
        {
            case 1:
                _rigidbody.AddForce(Vector3.back*70);
                break;
            case 2:
                _rigidbody.AddForce(Vector3.forward*70);
                break;
                    
        }

        _collider.enabled = false;
    }
}
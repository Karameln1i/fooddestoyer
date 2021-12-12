using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;
    [SerializeField] private VirtualCameraSwitcher _cameraSwitcher;


    private Animator _animator;
    private Transform[] _points;
    private int _currentPoint;

    public event UnityAction FallItemReached;
    public event UnityAction ControlPointReached;
    public event UnityAction<int> WayPointReached;
    public event UnityAction<GameObject> ReceivedLegTarget;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void OnEnable()
    {
        _animator.SetTrigger(PlayerAnimationController.Trigers.SwitchToWalk);
    }

    private void Start()
    {
        //_animator.SetTrigger(PlayerAnimationController.Trigers.SwitchToIdle);
        
        _points =new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
    
    private void Update()
     {
         Transform target = _points[_currentPoint];
         transform.position=Vector3.MoveTowards(transform.position,target.position,_speed*Time.deltaTime);
         CheckCurrentPoint(target);
     }

    private void CheckCurrentPoint(Transform target)
    {
        if (transform.position==target.position)
        {
                _currentPoint++;

                if (target.GetComponent<WayPoint>().IsFlyingWithJuiceItemWayPoint)
                {
                   WayPointReached?.Invoke(target.GetComponent<WayPoint>().FlyingWithJuiceItem.Endurance);
                }
                ControlPointReached?.Invoke();
                ReceivedLegTarget?.Invoke(target.GetComponent<WayPoint>().LegTarget);

                if (target.GetComponent<WayPoint>().IsFallItemWaypoit)
                {
                    FallItemReached?.Invoke();
                }
        }
    }

 
}

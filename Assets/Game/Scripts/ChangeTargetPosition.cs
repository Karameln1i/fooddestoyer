using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.Events;

[RequireComponent(typeof(Target))]
public class ChangeTargetPosition : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Vector3 _deltaPosition1;
    [SerializeField] private Vector3 _deltaPosition2;
    [SerializeField] private Vector3 _deltaRotation;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _legLiftingSpeed;
    [SerializeField] private float _legLoweringSpedForFlattening;
    [SerializeField] private LevelComplitedPanel _levelComplitedPanel;
    [SerializeField] private MoveState _moveState;
    [SerializeField] private GameObject _legPivot;
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private float _legLiftingDellay;
    [SerializeField] private float _maxYposition;

    [SerializeField] private float _legloweringSpeed;

    [SerializeField] private AnimationCurve _legLiftingSpead1;
    [SerializeField] private AnimationCurve _legLiftingSpead2;
    [SerializeField] private AnimationCurve _legLoweringSpead;
    
    private float _currentTime;
    private float _totalTime;


    private bool _isGoDown;
    private float _legSpeed;
    private float _legLoweringSpeedAfterTouching;
    private Target _target;
    private GameObject _endPoint;
    private Coroutine _moveToTergetJob;
    private int _clickCount;
    
    public float LegloweringSpeedForFlattening => _legLoweringSpedForFlattening;
    public bool IsGoDown => _isGoDown;
    public float LegloweringSpeed => _legloweringSpeed;
    private const float LegSpedForFlattening=0.1f;
    private const float LegLoweringSpeed=1f;
    private Coroutine MoveTargetInJob;
    private bool MoveTargetIsWorking;
    private bool _touchedFlyingWithJuiceItem;
    

    public event UnityAction TargetAchived;

    private void Awake()
    {
        _target = GetComponent<Target>();
        _totalTime = _legLiftingSpead1.keys[_legLiftingSpead1.keys.Length - 1].time;
    }

    private void OnEnable()
    {
       _playerCollisionHandler.TouchedFlyingWithJuiceItem += OnTouchedFlyingWithJuiceItem;
       _levelComplitedPanel.Opened += OnPanelOpened;
        _playerInput.Clicked += OnClicked;
    }

    
    
    private void OnDisable()
    {
       _playerCollisionHandler.TouchedFlyingWithJuiceItem -= OnTouchedFlyingWithJuiceItem;
       StopMoveToTarget();
    }

    private void OnPanelOpened()
    {
        enabled = false;
    }

    private IEnumerator Dellay(float time)
    {
        yield return new WaitForSeconds(time);
    }
    
    private IEnumerator MoveTarget()
    {
        MoveTargetIsWorking = true;
        _currentTime = 0;
        
        Vector3 targetPosition = _target.transform.position + _deltaPosition1;

        while (_target.transform.position!=targetPosition)
            {
                var speed=_legLiftingSpead1.Evaluate(_currentTime);
                _currentTime += Time.deltaTime;

                _target.transform.position=Vector3.MoveTowards(_target.transform.position,targetPosition,speed*Time.deltaTime);
                yield return null;
          
        }

        targetPosition += _deltaPosition2;
        
        while (_target.transform.position!=targetPosition)
        {
            var speed=_legLiftingSpead2.Evaluate(_currentTime);
            _currentTime += Time.deltaTime;

            _target.transform.position=Vector3.MoveTowards(_target.transform.position,targetPosition,speed*Time.deltaTime);
            
            yield return null;
          
        }
            yield return new WaitForSeconds(_legLiftingDellay);
            
            _currentTime = 0;

            _isGoDown = true;
            
            while (_target.transform.localPosition!=_target.StartPosition)
            {
                var speed=_legLoweringSpead.Evaluate(_currentTime);
                _currentTime += Time.deltaTime;

                if (!_touchedFlyingWithJuiceItem)
                {
                    _target.transform.localPosition=Vector3.MoveTowards(_target.transform.localPosition,_target.StartPosition,speed*Time.deltaTime);
                }
                else
                {
                    _target.transform.localPosition=Vector3.MoveTowards(_target.transform.localPosition,_target.StartPosition,_legSpeed*Time.deltaTime);
                }
                
                yield return null;
               
            }
        
            _currentTime = 0;

            TargetAchived?.Invoke();
        MoveTargetIsWorking = false;
        _isGoDown = false;
    }
    
        
    
    private void OnClicked()
    {
        if (_target.transform.position.y<_maxYposition)
        {
            if (MoveTargetIsWorking)
            {
              
                StopCoroutine(_moveToTergetJob);
                _moveToTergetJob=StartCoroutine(MoveTarget());
                _clickCount++;
            }
            else
            {
                _moveToTergetJob=StartCoroutine(MoveTarget());
            }
        }
    }

    private void StopMoveToTarget()
    {
        _target.ResetPosition();
    }

    private void OnTouchedFlyingWithJuiceItem(FlyingWithJuiceItem flyingWithJuiceItem)
    {
        if (!flyingWithJuiceItem.Disacarded)
        {
            flyingWithJuiceItem.Destroyed += OnflyingWithJuiceItemDestroyed;
            _legSpeed = _legLoweringSpedForFlattening;
            _touchedFlyingWithJuiceItem = true;
        }
    }

    private void OnflyingWithJuiceItemDestroyed()
    {
        _touchedFlyingWithJuiceItem = false;
    }
}

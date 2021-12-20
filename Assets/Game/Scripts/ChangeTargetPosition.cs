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
    [SerializeField] private ScaleValueChecker _scaleValueChecker;
    [SerializeField] private Vector3 _deltaPosition1;
  //  [SerializeField] private Vector3 _deltaPosition2;
    [SerializeField] private float _legLiftingSpeed;
    [SerializeField] private float _legLoweringSpead;
    [SerializeField] private float _legLoweringSpedForFlattening;
    [SerializeField] private LevelComplitedPanel _levelComplitedPanel;
    [SerializeField] private MoveState _moveState;
    [SerializeField] private GameObject _legPivot;
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;

    [SerializeField] private float _legloweringSpeed;

    //private float _legSpeed;
    private float _legLoweringSpeedAfterTouching;
    private Target _target;
    private GameObject _endPoint;
    private Coroutine _moveToTergetJob;
    private int _clickCount;
    
    public float LegloweringSpeedForFlattening => _legLoweringSpedForFlattening;
    public float LegloweringSpeed => _legloweringSpeed;
    private const float LegSpedForFlattening=0.1f;
    private const float LegLoweringSpeed=1f;
    

    public event UnityAction TargetAchived;

    private void Awake()
    {
        _target = GetComponent<Target>();
    }

    private void OnEnable()
    {
       _playerCollisionHandler.TouchedFlyingWithJuiceItem += OnTouchedFlyingWithJuiceItem;
     //  _moveState.WayPointReached += OnWayPointReached;
        _levelComplitedPanel.Opened += OnPanelOpened;
        _playerInput.Clicked += OnClicked;
        _scaleValueChecker.StopedOnGreen += OnStopedOnGreenZone;
        _scaleValueChecker.StopedYellow += OnStopedOnYellowZone;
        //_legloweringSpeed = _legLiftingSpeed;
     //   _moveState.ReceivedLegTarget += OnReceivedLegTarget;
        Debug.Log("cahngetargetpositionon");
    }

    
    
    private void OnDisable()
    {
       _playerCollisionHandler.TouchedFlyingWithJuiceItem -= OnTouchedFlyingWithJuiceItem;
        _scaleValueChecker.StopedOnGreen -= OnStopedOnGreenZone;
        _scaleValueChecker.StopedYellow -= OnStopedOnYellowZone;
       // _moveState.ReceivedLegTarget -= OnReceivedLegTarget;
       // _moveState.WayPointReached -= OnWayPointReached;
        StopMoveToTarget();
    }

    private void OnPanelOpened()
    {
        enabled = false;
    }
    
    public IEnumerator MoveTarget()
    {

        Debug.Log("moveTarget Started");
        
        Vector3 targetPosition1 = _target.transform.position + _deltaPosition1;

            while (_target.transform.position!=targetPosition1)
        {
            _target.transform.position=Vector3.MoveTowards(_target.transform.position,targetPosition1,_legLiftingSpeed*Time.deltaTime);
            yield return null;
        }
            
            //Vector3 targetPosition2 = _target.transform.position + _deltaPosition1;

            while (_target.transform.localPosition!=_target.StartPosition)
            {
                _target.transform.localPosition=Vector3.MoveTowards(_target.transform.localPosition,_target.StartPosition,_legLoweringSpead*Time.deltaTime);
                yield return null;
            }
            
            
     /*   while (_target.transform.position!=_endPoint.transform.position)
        {
            _target.transform.position=Vector3.MoveTowards(_target.transform.position,_endPoint.transform.position,_legloweringSpeed*Time.deltaTime);
          // Vector3 direction = _endPoint.transform.position - _target.transform.position;
           //_target.transform.Translate(direction*_legloweringSpeed*Time.deltaTime);
            //_target.transform.position=Vector3.Lerp(_target.transform.position,_endPoint.transform.position,_legloweringSpeed*Time.deltaTime);
            yield return null;
        }*/

        _clickCount = 0;
        TargetAchived?.Invoke();
        _target.ResetPosition();
        Debug.Log("всё");
    }

    private void OnReceivedLegTarget(GameObject legtarget)
    {
        _endPoint = legtarget;
    }
        
    
    private void OnClicked()
    {
        if (_clickCount==0)
        {
            Debug.Log(_clickCount);
            _moveToTergetJob=StartCoroutine(MoveTarget());
            _clickCount++;
        }
    }

    private void StopMoveToTarget()
    {
        StopCoroutine(_moveToTergetJob);
        _target.ResetPosition();
    }

    private void OnTouchedFlyingWithJuiceItem(FlyingWithJuiceItem flyingWithJuiceItem)
    {
        flyingWithJuiceItem.Destroyed += OnflyingWithJuiceItemDestroyed;
        _legloweringSpeed = _legLoweringSpedForFlattening;
    }
    
    private void OnWayPointReached(/*FlyingWithJuiceItem flyingWithJuiceItem,*/int endurance)
    {

       СalculateSpead(endurance);
    }

    private void СalculateSpead(int endurancce)
    {
        _legLoweringSpedForFlattening -= _legLoweringSpedForFlattening / 100 * endurancce;
        Debug.Log(_legLoweringSpedForFlattening);
    }
    
    private void OnflyingWithJuiceItemDestroyed()
    {
        _legLoweringSpedForFlattening =LegSpedForFlattening;
            Debug.Log("destroyed");
      _legloweringSpeed = LegLoweringSpeed;
    }
    
    private void OnStopedOnGreenZone()
    {
        //legloweringSpeed = _legLoweringSpeedForGreenZone;
      
    }
    
    private void OnStopedOnYellowZone()
    {
        //_legloweringSpeed= _legLoweringSpeedForYllowZone;
       
    }
}

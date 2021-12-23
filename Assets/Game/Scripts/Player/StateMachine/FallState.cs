using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FullBodyBipedIK),typeof(Animator),typeof(Player))]
public class FallState : MonoBehaviour
{
   // [SerializeField] private ScaleValueChecker _scaleValueChecker;
    [SerializeField] private CinemachineBrain _cinemachine;
    [SerializeField] private List<BoxCollider> _colliders;
    [SerializeField] private ChangeTargetPosition _changeTargetPosition;
    [SerializeField] private List<FallItem> _fallItems;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private RagdollActivator _ragdollActivator;


   // private MoveState _moveState;
    private StateMachine _stateMachine;
    private Animator _animator;
    private FullBodyBipedIK _fullBodyBipedIk;
    private Player _player;

    public event UnityAction AchievedFallItem;
    
    private void Awake()
    {
        
        _stateMachine = GetComponent<StateMachine>();
        _animator = GetComponent<Animator>();
        _fullBodyBipedIk = GetComponent<FullBodyBipedIK>();
        _player = GetComponent<Player>();
       // _moveState = GetComponent<MoveState>();


    }
    
    private void OnEnable()
    {
        _collisionHandler.TouchedFallItem += OnPlayerClicked;
        
        for (int i = 0; i < _fallItems.Capacity; i++)
        {
            _fallItems[i].TouchedFallItem += OnFallItemReached;
        }
        
        
    }

    private void OnDisable()
    {

        _collisionHandler.TouchedFallItem -= OnTouchedFallItem;
        
        for (int i = 0; i < _fallItems.Capacity; i++)
        {
            _fallItems[i].TouchedFallItem -= OnFallItemReached; 
        }
    }

    private void OnTouchedFallItem()
    {
        _ragdollActivator.ActivateRagDoll();
    }

    private void OnFallItemReached()
    {
        
      // StartCoroutine(_changeTargetPosition.MoveTarget());
       //_player.Lose();
       _virtualCamera.Follow = null;
       _animator.SetTrigger(PlayerAnimationController.Trigers.SwitchToIdle);
       _animator.applyRootMotion = true;
       _stateMachine.Off();
      Debug.Log("OnFallItemReached");
      _playerInput.enabled = true;
      _playerInput.Clicked += OnPlayerClicked;
      // TurnOffColdiers();
      AchievedFallItem?.Invoke();




    }

    private void OnPlayerClicked()
    {
        _animator.SetTrigger(PlayerAnimationController.Trigers.SwitchToFall);
        _animator.applyRootMotion = true;
        _fullBodyBipedIk.enabled = false;
        Debug.Log("clicked");
    }


}

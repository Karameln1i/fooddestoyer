using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(FullBodyBipedIK),typeof(Animator),typeof(Player))]
public class DestroyState : State
{

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ChangeTargetPosition _changeTargetPosition;
    [SerializeField] private Scale _scale;
    [SerializeField] private VirtualCameraSwitcher _cameraSwitcher;
    
    private FullBodyBipedIK _fullBodyBipedIk;
    private Animator _animator;

    public event UnityAction Launched;
    public event UnityAction Disabled;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _fullBodyBipedIk = GetComponent<FullBodyBipedIK>();
    }
    
    private void OnEnable()
    {
        //_animator.SetBool("DestroyStateTurnedOff",false);
       // _animator.SetBool("ReachedControlPoint",true);
       _animator.SetTrigger(PlayerAnimationController.Trigers.SwitchToIdle);
        EnableComponents(true);
        Launched?.Invoke();
        StartCoroutine(TurnOnScaleAfterTime());
        StartCoroutine(TurnOnPlayerInputAfterTime());
    }

    private void OnDisable()
    {
        //_animator.SetBool("ReachedControlPoint",false);
       // _animator.SetBool("DestroyStateTurnedOff",true);
        EnableComponents(false);
        Disabled?.Invoke();
    }

    private void EnableComponents(bool Bool)
    {
        //_changeTargetPosition.enabled=Bool;
        _fullBodyBipedIk.enabled = Bool;

       // if (Bool)
        //{
            //_cameraMove.enabled = false;
       // }
       if (!Bool)
       {
           _playerInput.enabled = Bool;
       }
        {
            //_scale.TurnOf();
           //_cameraMove.enabled = true;

        }
    }



    private IEnumerator TurnOnScaleAfterTime()
    {
        yield return new WaitForSeconds(1);
        _scale.TurnOn();
    }
    
    private IEnumerator TurnOnPlayerInputAfterTime()
    {
        yield return new WaitForSeconds(1);
        _playerInput.enabled = true;
    }
   
    
    
  

} 

using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
public class VirtualCameraSwitcher : MonoBehaviour
{
    [SerializeField] private float _playerInputDisabledTime;
    [SerializeField] private CinemachineVirtualCamera _cameraForWalking;
    [SerializeField] private CinemachineVirtualCamera _cameraForFall;
    [SerializeField] private FallState _fallState;
    [SerializeField] private PlayerInput _playerInput;

    private const int _priorityValue = 1;
    private const int _notPriorityValue = 0;

    private void OnEnable()
    {
        _fallState.AchievedFallItem += OnAchievedFallItem;
    }

    private void OnDisable()
    {
        _fallState.AchievedFallItem -= OnAchievedFallItem;
    }
    
    private void OnAchievedFallItem()
    {
        _cameraForWalking.Priority = _notPriorityValue;
        _cameraForFall.Priority = _priorityValue;

        //DisablePlayerInputForAtime();
    }

    private void DisablePlayerInputForAtime()
    {
        StartCoroutine(DisableInputForWhile());
    }
    
    private IEnumerator DisableInputForWhile()
    {
        _playerInput.enabled = false;
        yield return new WaitForSeconds(_playerInputDisabledTime);
        _playerInput.enabled = true;
    }
}

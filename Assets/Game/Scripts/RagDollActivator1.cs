using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RagDollActivator : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    
    private Animator _animator;

    private void Awake()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = true;
        }
    }

   public void Activate()
    {
        _animator.enabled = false;

        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RagdollActivator : MonoBehaviour
{
    [SerializeField] private List<CapsuleCollider> _capsuleColliders;
    [SerializeField] private List<BoxCollider> _boxColliders;
    [SerializeField] private List<Rigidbody> _rigidbodies;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void ActivateRagDoll()
    {
        _animator.enabled = false;
        for (int i = 0; i < _capsuleColliders.Count; i++)
        {
            _capsuleColliders[i].enabled = true;
        }

        for (int i = 0; i < _boxColliders.Count; i++)
        {
            _boxColliders[i].enabled = true;
        }
        
       /* for (int i = 0; i < _rigidbodies.Count; i++)
        {
            //_rigidbodies[i].enabled = true;
        }*/

    }
}

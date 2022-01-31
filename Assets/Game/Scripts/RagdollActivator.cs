using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(FullBodyBipedIK))]
public class RagdollActivator : MonoBehaviour
{
    [SerializeField] private List<CapsuleCollider> _capsuleColliders;
    [SerializeField] private List<BoxCollider> _boxColliders;
    [SerializeField] private List<Rigidbody> _rigidbodies;
    
    private Animator _animator;
    private FullBodyBipedIK _fullBodyBipedIk;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _fullBodyBipedIk = GetComponent<FullBodyBipedIK>();
        
        for (int i = 0; i < _capsuleColliders.Count; i++)
        {
            _capsuleColliders[i].enabled = true;
        }

        for (int i = 0; i < _boxColliders.Count; i++)
        {
            _boxColliders[i].enabled = true;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ActivateRagDoll();
        }
    }
    
    public void ActivateRagDoll()
    {
        _animator.enabled = false;
        _fullBodyBipedIk.enabled = false;
        
        for (int i = 0; i < _rigidbodies.Count; i++)
        {
            _rigidbodies[i].useGravity = true;
            _rigidbodies[i].AddForce(Vector3.up*400);
        }

    }
}

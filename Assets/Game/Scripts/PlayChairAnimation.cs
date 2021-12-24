using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayChairAnimation : MonoBehaviour
{
   [SerializeField] private FallState _fallState;
   
   private Animator _animator;

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

   private void OnEnable()
   {
      _fallState.Falling += OnFalling;
   }

   private void OnDisable()
   {
      _fallState.Falling -= OnFalling;
   }

   private void OnFalling()
   {
      _animator.Play("Shaiking");
      Debug.Log("падаю");
   }
   
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public  class PlayerAnimationController:MonoBehaviour
{
    [SerializeField] private  List<AnimationClip> _fallAnimations;
    
    public static class States
    {
        public static string Idle = nameof(Idle);
        public static string Walk = nameof(Walk);
    }

    public static class  Trigers
    {
        public  const string SwitchToWalk = nameof(SwitchToWalk);
        public  const string SwitchToIdle = nameof(SwitchToIdle);
        public const string SwitchToFall = nameof(SwitchToFall);
    }
    
    public AnimationClip GetRandomFallAnimation()
    {
        return _fallAnimations[Random.Range(0,_fallAnimations.Count)];
    }
}

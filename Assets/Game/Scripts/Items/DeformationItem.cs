using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DeformationItem : Item
{
    [SerializeField] private  GameObject _boneToChangePosition;
    [SerializeField] private  GameObject _rightBoneToChangeRotation;
    [SerializeField] private  GameObject _leftBoneToChangeRotation;
    [SerializeField] private GameObject _replacedModel;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private List <ParticleSystem>  _effects;
    [SerializeField] private bool _replaceModel;
    [SerializeField] private bool _turningTheSecondBone;
    [SerializeField] private bool _playEffects;
    [SerializeField] private bool _deformateBone;
    [SerializeField] private float _speedMultiplayer;
    [SerializeField] private float _deformateSpeed;
    [SerializeField] private Vector3 _RightBonerotationTarget;
    [SerializeField] private Vector3 _LeftBonerotationTarget;
    [SerializeField] private Transform _boneTarget;
    [SerializeField] private float _minBoneScale;
    [SerializeField] private SkinnedMeshRenderer _whole;
    [SerializeField] private GameObject _emoji;
    [SerializeField] private BoxCollider _boxColdier;
    

    private bool _rotated;
    private bool _effecIsPlayed;
    private Item item;

    private void Awake()
    {
        item = GetComponent<Item>();
    }

    private void OnEnable()
    {
        item.Destroyed += OnItemDestroyed;
    }

    private void OnDisable()
    {
        item.Destroyed -= OnItemDestroyed;
    }

    private void OnItemDestroyed(Item item)
    {

        if (_replaceModel)
        {
            _replacedModel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void TryPlayEffects()
    {
        if (_playEffects)
        {
            for (int i = 0; i < _effects.Count; i++)
            {
                _effects[i].Play();
            } 
        }
    }

    private void RotateBones()
    {
        if (!_rotated)
        {
            _rightBoneToChangeRotation.transform.DOLocalRotate(_RightBonerotationTarget, _rotationSpeed);

            if (_turningTheSecondBone)
            {
                _leftBoneToChangeRotation.transform.DOLocalRotate(_LeftBonerotationTarget, _rotationSpeed);
            }
            _rotated = true;
        }
    }
    
    public override void Deform(float speed,GameObject legPivot,bool IsGoDown)
    {
        Debug.Log(IsGoDown);

        if (legPivot.transform.position.y>TopPoint.transform.localPosition.y && IsGoDown)
        {
            RotateBones();
            StartCoroutine(Deformate());
            _isDestroyed = true;
            StartCoroutine(DestroyedAfterTime());
            
            if (_deformateBone)
            {
                _boneToChangePosition.transform.DOScaleZ(_minBoneScale, _deformateSpeed);
            }
       
            if (!_effecIsPlayed)
            {
                TryPlayEffects();
                _effecIsPlayed = true;
            }
        }

        else
        {
            Discard();
        }
        
        if (_replaceModel)
        {
            _replacedModel.SetActive(true);
            _emoji.SetActive(false);
            _whole.enabled = false;
        }
    }

    private IEnumerator Deformate()
    {

        while (_boneToChangePosition.transform.position != _boneTarget.transform.position)
        {
            _boneToChangePosition.transform.position = Vector3.MoveTowards(_boneToChangePosition.transform.position,
                _boneTarget.transform.position, _deformateSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator DestroyedAfterTime()
    {
        yield return new WaitForSeconds(0.1f);
        Desrtoyed();
        gameObject.SetActive(true);
        BoxCollider.enabled = false;
        Rigidbody.useGravity = false;

    }
}

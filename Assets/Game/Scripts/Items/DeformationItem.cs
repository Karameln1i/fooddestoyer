using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private float _speedMultiplayer;

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
        _rightBoneToChangeRotation.transform.Rotate(Vector3.right,_rotationSpeed*Time.deltaTime);

        if (_turningTheSecondBone)
        {
            _leftBoneToChangeRotation.transform.Rotate(Vector3.left,_rotationSpeed*Time.deltaTime);
        } 
    }
    
    public override void Deform(float speed)
    {
        base.Deform(speed);

        if (!_effecIsPlayed)
        {
            TryPlayEffects();
            _effecIsPlayed = true;
        }
        
       RotateBones();
       _boneToChangePosition.transform.position=Vector3.MoveTowards(_boneToChangePosition.transform.position,item.LegTarget.transform.position,speed*_speedMultiplayer*Time.deltaTime);
           //_boneToChangePosition.transform.Translate(Vector3.down*speed*_speedMultiplayer);
    }

    
}

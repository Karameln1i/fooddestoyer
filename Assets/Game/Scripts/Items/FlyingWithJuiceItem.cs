using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RayFire;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody),typeof(Animator))]
public class FlyingWithJuiceItem : Item
{
    [SerializeField] private float _bombDellay;
    [SerializeField] private List<Rigidbody> _rigidbodies;
    [SerializeField] private List<MeshCollider> _meshColliders;
    [SerializeField] private RayfireBomb _bomb;
    [SerializeField] private List<ParticleSystem> _firstWaveEffects;
    [SerializeField] private List <ParticleSystem> _effects;
    [SerializeField] private float _minScale;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private GameObject _sliced;
    [SerializeField] private MeshRenderer _wholeMesh;
    [SerializeField] private bool _isGorizontalItem;
    [SerializeField] private bool _useTwoWavesOfEffects;
    [SerializeField] private float _scaleZDeformateSpead;
    [SerializeField] private int _endurance;
    [SerializeField] private Color _explosionColor;
    [SerializeField] private float _deformateSpeed;
    [SerializeField] private List<BoxCollider> _boxCodiers;
    [SerializeField] private GameObject _emoji;
    
    private Coroutine _deformate;
    private bool _isDeformated;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private GameObject _TopPoint;
    private bool _discarded;
    private const float dellay = 2f;

    public bool Disacarded => _discarded;
    public int Endurance => _endurance;
    public event UnityAction Destroyed;
    public event UnityAction<FlyingWithJuiceItem> Exploaded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _TopPoint = TopPoint;
    }
    
    private  void BlowUp()
    {
        _bomb.Explode(_bombDellay);
        PlayEffects();
        _animator.enabled = false;
       _emoji.SetActive(false);
        _wholeMesh.enabled = false;
        _sliced.SetActive(true);
        Destroyed?.Invoke();
        Exploaded?.Invoke(this);
        _rigidbody.useGravity = false;
        Desrtoyed();
       StartCoroutine( Dellay());

        for (int i = 0; i < _boxCodiers.Capacity; i++)
        {
            _boxCodiers[i].enabled = false;
        }
    }

    protected override void Flatten(float speed,GameObject legPivot,bool IsGoDown)
    {
        if (legPivot.transform.position.y>TopPoint.transform.localPosition.y&& IsGoDown)
        {
            _isDestroyed = true;
            StartCoroutine(Deformate(speed));
        }
       
        else
        {
            Discard();
            for (int i = 0; i < _boxCodiers.Capacity; i++)
            {
                _boxCodiers[i].enabled = false;
            }
            _discarded = true;
        }
    }

  private void Discard()
    {
        _rigidbody.AddForce(Vector3.up*70);
        _rigidbody.AddForce(Vector3.right*70);

        var directionIndex = Random.Range(1, 3);
        
        switch (directionIndex)
        {
            case 1:
                _rigidbody.AddForce(Vector3.back*70);
                break;
                case 2:
                    _rigidbody.AddForce(Vector3.forward*70);
                    break;
                    
        }
    }

  private IEnumerator Deformate(float speed)
    {

        for (int i = 0; i < _firstWaveEffects.Capacity; i++)
        {
            _firstWaveEffects[i].Play();
        }

        var deformateSpeed = _speedMultiplier * speed;
        var scaleY = transform.localScale.y;

            while (transform.localScale.y>_minScale)
            {
                scaleY = Mathf.MoveTowards(scaleY, _minScale, deformateSpeed * Time.deltaTime);
                transform.localScale=new Vector3(transform.localScale.x,scaleY,transform.localScale.z);
                yield return null;
            }
            for (int i = 0; i < _firstWaveEffects.Capacity; i++)
        {
            _firstWaveEffects[i].Stop();
        }
            BlowUp();
    }
    
    private void PlayEffects()
    {
        for (int i = 0; i < _effects.Count; i++)
        {
            _effects[i].Play();
        }
    }
    
    private void TurnOnColdiers()
    {
        for (int i = 0; i < _meshColliders.Capacity; i++)
        {
            _meshColliders[i].enabled = true;
        }
    }

    private void UseGravity()
    {
        for (int i = 0; i < _rigidbodies.Capacity; i++)
        {
            _rigidbodies[i].useGravity = true;
            _rigidbodies[i].isKinematic = false;
        }
    }

    private IEnumerator Dellay()
    {
        yield return new WaitForSeconds(dellay);
        SetTrigerOnColdiers();
    }

    private void SetTrigerOnColdiers()
    {
        for (int i = 0; i < _meshColliders.Capacity; i++)
        {
            _meshColliders[i].isTrigger = true;
        }
    }
}

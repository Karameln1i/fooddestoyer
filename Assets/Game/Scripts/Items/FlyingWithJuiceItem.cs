using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RayFire;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] private bool _isGorizontalItem;
    [SerializeField] private bool _useTwoWavesOfEffects;
    [SerializeField] private float _scaleZDeformateSpead;
    [SerializeField] private int _endurance;
    [SerializeField] private Color _explosionColor;

    private Coroutine _deformate;
    private bool _isDeformated;

    public int Endurance => _endurance;
    public event UnityAction Destroyed;
    public event UnityAction<Color> Exploaded;
    
    private  void BlowUp()
    {
        
        PlayEffects();
        UseGravity();
        TurnOnColdiers();
        _bomb.Explode(_bombDellay);
        gameObject.SetActive(false);
        _sliced.SetActive(true);
        Desrtoyed();
        Destroyed?.Invoke();
        Exploaded?.Invoke(_explosionColor);
    }

    protected override void Flatten(float speed)
    {
        //base.Deform(speed);

        StartCoroutine(poc(speed));
    }

    private IEnumerator poc(float speed)
    {
        yield return new WaitForSeconds(0.1f);
        _deformate=StartCoroutine(Deformate(speed));
    }
    
    private IEnumerator Deformate(float speed)
    {

        for (int i = 0; i < _firstWaveEffects.Capacity; i++)
        {
            _firstWaveEffects[i].Play();
        }

        var deformateSpeed = _speedMultiplier * speed;
        
        if (_isGorizontalItem)
        {
            var scaleZ = transform.localScale.z;
            var positionY = transform.position.y;
 
        
            Debug.Log("spead "+deformateSpeed);
        
            while (transform.localScale.z>_minScale)
            {
                scaleZ = Mathf.MoveTowards(scaleZ, _minScale, deformateSpeed * Time.deltaTime);
                //0,095
                positionY = Mathf.MoveTowards(positionY, 0.095f,deformateSpeed * Time.deltaTime);
                transform.localScale=new Vector3(transform.localScale.x,transform.localScale.y,scaleZ);
                transform.position=new Vector3(transform.position.x,positionY,transform.position.z);
                yield return null;
            }
        }
        else
        {
            var scaleY = transform.localScale.y;
 
        Debug.Log("Пришедшая скорость "+speed);
            Debug.Log("deformateSpeed "+deformateSpeed);
        
            while (transform.localScale.y>_minScale)
            {
                scaleY = Mathf.MoveTowards(scaleY, _minScale, deformateSpeed * Time.deltaTime);
               // scaleY = ;
               //transform.DOScale(_deformated, deformateSpeed);
                  // Vector3.Lerp(transform.localScale, _deformated, deformateSpeed);
                transform.localScale=new Vector3(transform.localScale.x,scaleY,transform.localScale.z);
                yield return null;
            }
        }
        // StopCoroutine(_deformate);
        for (int i = 0; i < _firstWaveEffects.Capacity; i++)
        {
            _firstWaveEffects[i].Stop();
        }
        //_isDeformated = true;
      BlowUp();
      Desrtoyed();
    
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
        }
    }
}

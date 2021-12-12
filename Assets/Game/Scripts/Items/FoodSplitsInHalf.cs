using System.Collections;
using System.Collections.Generic;
using RayFire;
using UnityEngine;

public class FoodSplitsInHalf : Item
{
    [SerializeField] private float _bombDellay;
    [SerializeField] private GameObject _sliced;
    [SerializeField] private ParticleSystem _explossion;
    [SerializeField] private ParticleSystem _puddleOfJuici;
    [SerializeField] private RayfireBomb _bomb;
    
   protected override void Break()
    {
        _sliced.SetActive(true);
        gameObject.SetActive(false);
        _bomb.Explode(_bombDellay);
        _explossion.Play();
        _puddleOfJuici.Play();
        Desrtoyed();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCreator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void CreateEffect(Vector3 position)
    {
        var effect = Instantiate(_effect.transform);
        effect.transform.position = position;;
    }
    
}

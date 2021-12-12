using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleValueChecker : MonoBehaviour
{
    [SerializeField] private float[] FirstRedZoneDiapozon=new float[1];
    [SerializeField] private float[] SecondRedZoneDiapozon=new float[1];
    [SerializeField] private float[] FirstYellowZoneDiapozon=new float[1];
    [SerializeField] private float[] SecondYellowZoneDiapozon=new float[1];
    [SerializeField] private float[] GreenZoneDiapozon=new float[1];

    private float _value;

    public event UnityAction StopedOnGreen;
    public event UnityAction StopedYellow;
    public event UnityAction StopedOnRed;
    
   
    
    private void CheckValue()
    {
        if (_value<FirstRedZoneDiapozon[1]|_value>SecondRedZoneDiapozon[0])
        {
            StopedOnRed?.Invoke();
        }
        else if (_value>FirstYellowZoneDiapozon[0]&&_value<FirstYellowZoneDiapozon[1])
        {
            StopedYellow?.Invoke();
        }
        else if (_value>SecondYellowZoneDiapozon[0]&&_value<SecondYellowZoneDiapozon[1])
        {
            StopedYellow?.Invoke();
        }
        else if (_value>GreenZoneDiapozon[0]&&_value<GreenZoneDiapozon[1])
        {
            StopedOnGreen?.Invoke();
        }
    }

    public void ApplyValue(float value)
    {
        _value = value;
        CheckValue();
    }
}

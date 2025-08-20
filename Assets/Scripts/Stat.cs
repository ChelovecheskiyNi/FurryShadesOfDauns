using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Stat : MonoBehaviour
{
    public UnityEvent onValueChanges;

    public float value = 50;
    public float maxValue = 50;
    [SerializeField] private float valuePerTimePass = 0.1f;

    public void SetValue(float _value)
    {
        value = Mathf.Min(maxValue, _value);
    }
    public void RemoveValuePerTimePass(int timePasses)
    {
        value = Mathf.Max(0, value - (timePasses * valuePerTimePass));
    }
}

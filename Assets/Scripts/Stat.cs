using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Stat
{
    public UnityEvent onValueChanges;

    public float value;
    public float maxValue;
    [SerializeField] private float valuePerTimePass;

    public void SetValue(float _value)
    {
        value = Mathf.Max(Mathf.Min(maxValue, _value), 0);
    }
    public void RemoveValuePerTimePass(int timePasses)
    {
        value = Mathf.Max(0, value - (timePasses * valuePerTimePass));
    }
    public void AddValue(float _addValue)
    {
        value = Mathf.Min(maxValue, value + _addValue);
    }
}

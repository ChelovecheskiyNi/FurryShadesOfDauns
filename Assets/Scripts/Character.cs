using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Stat Food;
    public Stat Mood;

    public virtual void Init()
    {

    }

    public virtual void StatsTimePass(int _timePass)
    {
        Food.RemoveValuePerTimePass(_timePass);
        Mood.RemoveValuePerTimePass(_timePass);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Timepass : MonoBehaviour
{
    [HideInInspector] public Timepass instance;
    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(this);

        if (!PlayerPrefs.HasKey("LastTime")) return;
        DateTime lastTime = DateTime.FromBinary(long.Parse(PlayerPrefs.GetString("LastTime")));

        if (DateTime.UtcNow.Subtract(lastTime).TotalHours > obviousDeathHours) IntantDeath();
        else TimePass((int)DateTime.UtcNow.Subtract(lastTime).TotalMinutes);
    }

    public UnityEvent<int> onTimePass;
    public UnityEvent onInstantDeath;

    [SerializeField] private int minutesForOnePass = 5;
    [SerializeField] private int obviousDeathHours = 24;
    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= minutesForOnePass) TimePass(1);
    }

    public void TimePass(int _passes)
    {
        timer = 0;
        onTimePass?.Invoke(_passes);
    }
    public void IntantDeath()
    {
        onInstantDeath?.Invoke();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastTime", $"{DateTime.UtcNow.ToBinary()}");
        PlayerPrefs.Save();
    }
}

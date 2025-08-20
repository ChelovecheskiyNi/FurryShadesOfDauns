using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timepass : MonoBehaviour
{
    public Timepass instance;
    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public UnityEvent<int> onTimePass;
    [SerializeField] private float timeForOnePass = 600;
    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeForOnePass) TimePass(1);
    }

    public void TimePass(int _passes)
    {
        timer = 0;
        onTimePass?.Invoke(_passes);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastTime", JsonUtility.ToJson(System.DateTime.Now));
        PlayerPrefs.Save();
    }
}

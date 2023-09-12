using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime; 
    public float timeLeft;
    public bool isOn; 

    public bool timerHasFinished = false; 

    public void setTotalTime(float pTime) => totalTime = pTime;

    public void startTimer()
    {
        timeLeft = totalTime;
        isOn = true;
        timerHasFinished = false; 
    }

    void Update()
    {
        if(isOn)
        {
            timeLeft -= Time.deltaTime; 
            if(timeLeft <= 0)
            {
                isOn = false;
                timerHasFinished = true; 
            }
        }
    }
}

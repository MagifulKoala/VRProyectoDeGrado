using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime; 
    public float timeLeft;
    public bool isOn; 

    public bool timerHasFinished = false; 



    public void setTotalTime(float pTime) => totalTime = pTime;
    public float getTimeLeft() => timeLeft; 

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
            //Debug.Log(timeLeft);
            timeLeft -= Time.deltaTime; 
            if(timeLeft <= 0)
            {
                isOn = false;
                timeLeft = 0;
                timerHasFinished = true; 
            }
        }
    }
}

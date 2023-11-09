using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class explosionProgressControl : MonoBehaviour
{

    //first challenge
    [SerializeField] explosiveCheck wallExplosiveCheck; 
    int currentChallenge = 0;

    public UnityEvent firstChallengeComplete;

    private void Start()
    {
        initializeFirstChallenge();
    }


    //first challenge
    private void initializeFirstChallenge()
    {
        wallExplosiveCheck.explosionDetected.AddListener(wallDestroyed);
    }

    private void wallDestroyed()
    {
        challengeComplete();
        firstChallengeComplete?.Invoke(); 
    }



    //extra
    private void challengeComplete()
    {
        currentChallenge++;
    }
}

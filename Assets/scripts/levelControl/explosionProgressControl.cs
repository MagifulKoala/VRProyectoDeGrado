using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Events;

public class explosionProgressControl : MonoBehaviour
{

    //first challenge
    [Header("first challenge")]
    [SerializeField] explosiveCheck wallExplosiveCheck;

    //second challenge
    [Header("second challenge")]
    [SerializeField] explosiveCheck bluePillar;
    [SerializeField] explosiveCheck yellowPillar;
    [SerializeField] explosiveCheck redPillar;

    public string currentCombo = "";
    //must be a combination of y, r, b with length no longer to 3
    public string solution = "yrb";

    [Header("third challenge")]
    [SerializeField] explosiveCheck wizard; 

    //other stuff
    int currentChallenge = 0;


    public UnityEvent firstChallengeComplete;
    public UnityEvent secondChallengeComplete;
    public UnityEvent thirdChallengeComplete; 

    private void Start()
    {
        initializeFirstChallenge();
        initializeSecondChallenge();
        initializeThirdChallenge();
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

    //second challenge

    private void initializeSecondChallenge()
    {
        yellowPillar.explosionDetected.AddListener(yellowPillarActivated);
        redPillar.explosionDetected.AddListener(redPillarActivated);
        bluePillar.explosionDetected.AddListener(bluePillarActivated);

    }

    private void bluePillarActivated()
    {
        currentCombo += "b";
        checkCombo();
    }

    private void redPillarActivated()
    {
        currentCombo += "r";
        checkCombo();
    }

    private void yellowPillarActivated()
    {
        currentCombo += "y";
        checkCombo();
    }

    private void checkCombo()
    {
        if (currentCombo.Length >= 3)
        {
            if (currentCombo.Equals(solution))
            {
                Debug.Log("second challenge complete");
                challengeComplete();
                secondChallengeComplete?.Invoke();
            }
            currentCombo = "";
        }
    }

    //thirdChallenge


    private void initializeThirdChallenge()
    {
        wizard.explosionDetected.AddListener(wizardDefeated);
    }

    private void wizardDefeated()
    {
        challengeComplete();
        thirdChallengeComplete?.Invoke(); 

    }



    //extra
    private void challengeComplete()
    {
        currentChallenge++;
    }
}

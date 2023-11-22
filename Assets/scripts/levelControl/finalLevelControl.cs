using UnityEngine;
using UnityEngine.Events;

public class finalLevelControl : MonoBehaviour
{
    [Header("First Challenge")]
    [SerializeField] public explosiveCheck firstWallCheck;
    [SerializeField] ObjectControll skull;

    [Header("SecondChallenge")]
    [SerializeField] public explosiveCheck secondWallCheck;

    [Header("Final Challenge")]
    [SerializeField] DoorSocketControll finalDoor;


    public UnityEvent firstChallengeComplete;
    public UnityEvent secondChallengeComplete;
    public UnityEvent thirdChallengeComplete;

    public UnityEvent fourthChallengeComplete;


    //extra stuff
    int currentChallenge = 0;

    private void Start()
    {
        initializeFirstChallenge();
        initializeSecondChallenge();
        initializeThirdChallenge();
    }

    //third challenge
    private void initializeThirdChallenge()
    {
        //finalDoor.doorUnlocked.AddListener(finalDoorOpened);
        secondWallCheck.explosionDetected.AddListener(secondWallBreached);
    }

    private void finalDoorOpened()
    {
        thirdChallengeComplete?.Invoke(); 
    }

    //First challenge
    private void initializeFirstChallenge()
    {
        if (firstWallCheck != null)
        {
            skull.GetComponent<ObjectControll>().ObjectDestroyed.AddListener(skullDestroyed);
        }
    }

    private void skullDestroyed()
    {
        challengeComplete();
        firstChallengeComplete?.Invoke();
    }

    private void firstWallBreached()
    {
        challengeComplete();
        firstChallengeComplete?.Invoke();
    }

    //second challenge

    private void initializeSecondChallenge()
    {
        if (secondWallCheck != null)
        {
            firstWallCheck.explosionDetected.AddListener(firstWallBreached);
        }
    }

    private void secondWallBreached()
    {
        challengeComplete();
        thirdChallengeComplete?.Invoke();
    }


    //extra stuff
    public void challengeComplete()
    {
        currentChallenge++;
    }
}


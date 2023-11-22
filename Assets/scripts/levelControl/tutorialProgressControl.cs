using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class tutorialProgressControl : MonoBehaviour
{
    [Header("First Challenge")]
    [SerializeField] ButtonInteractible dialogueButton;

    [Header("Second Challenge")]
    [SerializeField] XRGrabInteractable woodPillar;

    [Header("Third Challenge")]
    [SerializeField] XRGrabInteractable stoneSword;

    [Header("fourth challenge")]
    [SerializeField] ObjectControll stoneSwordOnFire;

    [Header("fifth challenge")]
    [SerializeField] ObjectControll iceCube;

    [Header("sixth challenge")]
    [SerializeField] DoorSocketControll prisonSocket;


    //current challenge number
    private int currentChallenge = 0;
    //challenge events
    public UnityEvent firstChallengeCompleteEvent;
    public UnityEvent secondChallengeCompleteEvent;
    public UnityEvent thirdChallengeCompleteEvent;
    public UnityEvent fourthChallengeCompleteEvent;
    public UnityEvent fifthChallengeCompleteEvent;
    public UnityEvent sixthChallengeCompleteEvent;


    private void Start()
    {
        initializeFirstChallenge();
        initializeSecondChallenge();
        initializeThirdChallenge();
        initializeFourthChallenge();
        initializeFifthChallenge();
        initializeSixthChallenge();
    }


    //First challenge
    private void initializeFirstChallenge()
    {
        dialogueButton.selectEntered.AddListener(dialogueFirstInteracted);
    }

    private void dialogueFirstInteracted(SelectEnterEventArgs arg0)
    {
        if (currentChallenge == 0)
        {
            challengeComplete();
            firstChallengeCompleteEvent?.Invoke();
        }
    }

    //second challenge


    private void initializeSecondChallenge()
    {
        woodPillar.selectEntered.AddListener(woodPillarInteracted);
    }

    private void woodPillarInteracted(SelectEnterEventArgs arg0)
    {
        Debug.Log(arg0.interactorObject.transform.gameObject.name);
        if (arg0.interactorObject.transform.gameObject.name.Equals("Left Direct Interactor") && currentChallenge == 1)
        {
            if (currentChallenge == 1)
            {
                challengeComplete();
                secondChallengeCompleteEvent?.Invoke();
            }
        }
    }

    //third challenge

    private void initializeThirdChallenge()
    {
        stoneSword.selectEntered.AddListener(stoneSowrdInteracted);
    }

    private void stoneSowrdInteracted(SelectEnterEventArgs arg0)
    {
        if (currentChallenge == 2 && arg0.interactorObject.transform.gameObject.name.Equals("Right Direct Interactor"))
        {
            challengeComplete();
            thirdChallengeCompleteEvent?.Invoke();
        }
    }

    //fourth challenge

    private void initializeFourthChallenge()
    {
        stoneSwordOnFire.objectOnFire.AddListener(swordBurning);
    }

    private void swordBurning()
    {
        if (currentChallenge == 3)
        {
            challengeComplete();
            fourthChallengeCompleteEvent?.Invoke();
        }
    }

    //fifth challenge


    private void initializeFifthChallenge()
    {
        iceCube.ObjectDestroyed.AddListener(iceMelted);
    }

    private void iceMelted()
    {
        if (currentChallenge == 4)
        {
            challengeComplete();
            fifthChallengeCompleteEvent?.Invoke();
        }
    }


    //sixth challenge

    private void initializeSixthChallenge()
    {
        prisonSocket.doorUnlocked.AddListener(prisonDoorUnlocked);
    }

    private void prisonDoorUnlocked()
    {
        if (currentChallenge == 5)
        {
            challengeComplete();
            sixthChallengeCompleteEvent?.Invoke();
        }
    }


    //extra stuff
    public void challengeComplete()
    {
        currentChallenge++;
    }
}

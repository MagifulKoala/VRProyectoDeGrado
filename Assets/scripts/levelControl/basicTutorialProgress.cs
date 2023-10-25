using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class basicTutorialProgress : MonoBehaviour
{
    [Header("First Room")]
    [SerializeField] boxTrigger firstRoomBoxTrigger;

    [Header("Second room")]
    [SerializeField] XRGrabInteractable blueCube;
    [SerializeField] XRGrabInteractable redCube;
    [SerializeField] DoorHingeInteractible yellowDoor;
    [SerializeField] DoorHingeInteractible[] cabinetDoors;
    [SerializeField] DrawerLock drawer;
    [SerializeField] DoorSocketControll lockedDoorSocket;

    [Header("Third Room")]
    //first area
    [SerializeField] XRGrabInteractable handsOfMidasParent;
    //second area
    [SerializeField] XRGrabInteractable cube1;
    [SerializeField] XRGrabInteractable cube2;
    [SerializeField] XRGrabInteractable cube3;
    [SerializeField] XRGrabInteractable cube4;
    //third area
    [SerializeField] buttonControl button1;
    [SerializeField] buttonControl button2;
    [SerializeField] buttonControl button3;
    [SerializeField] buttonControl button4;



    private bool firstAreaInteracted = false;
    private bool secondAreaInteracted = false;
    private bool thirdAreaInteracted = false;

    private bool firstAreaR3Interacted = false;
    private bool secondAreaR3Interacted = false;
    private bool thirdAreaR3Interacted = false;

    public int challengeNumber = 0;

    //challenge events
    public UnityEvent firstChallengeComplete;
    public UnityEvent secondChallengeComplete;

    public UnityEvent thirdChallengeComplete;
    public UnityEvent fourthChallengeComplete;

    //area iteraction events
    public UnityEvent firstAreaInteractedEvent;
    public UnityEvent secondAreaInteractedEvent;
    public UnityEvent thirdAreaInteractedEvent;

    //third area interaction events
    public UnityEvent firstAreaR3InteractedEvent;
    public UnityEvent secondAreaR3InteractedEvent;
    public UnityEvent thirdAreaR3InteractedEvent;



    void Start()
    {
        if (firstRoomBoxTrigger != null)
        {
            setFirstRoomTrigger();
        }
        setSecondRoomTriggers();
        setThirdRoomTriggers();
    }



    //first room methods

    private void setFirstRoomTrigger()
    {
        firstRoomBoxTrigger.triggerEntered.AddListener(firstRoomTriggered);
    }

    private void firstRoomTriggered()
    {
        if (challengeNumber == 0)
        {
            firstChallengeComplete?.Invoke();
            challengeComplete();
        }
    }

    // second room methods

    private void setSecondRoomTriggers()
    {
        blueCube.selectEntered.AddListener(blueCubeInteracted);
        redCube.selectEntered.AddListener(redCubeInteracted);

        cabinetDoors[0].selectEntered.AddListener(firstDoorInteracted);
        cabinetDoors[1].selectEntered.AddListener(secondDoorInteracted);
        yellowDoor.selectEntered.AddListener(yellowDoorInteracted);
        drawer.selectEntered.AddListener(drawerInteracted);

        lockedDoorSocket.doorUnlocked.AddListener(basicDoorUnlocked);
    }

    private void basicDoorUnlocked()
    {
        if (!thirdAreaInteracted)
        {
            thirdAreaInteracted = true;
            thirdAreaInteractedEvent?.Invoke();
            checkSecondRoomComplete();
        }
    }

    private void yellowDoorInteracted(SelectEnterEventArgs arg0)
    {
        if (!secondAreaInteracted)
        {
            secondAreaInteracted = true;
            secondAreaInteractedEvent?.Invoke();
            checkSecondRoomComplete();
        }
    }

    private void drawerInteracted(SelectEnterEventArgs arg0)
    {
        if (!secondAreaInteracted)
        {
            secondAreaInteracted = true;
            secondAreaInteractedEvent?.Invoke();
            checkSecondRoomComplete();
        }
    }

    private void secondDoorInteracted(SelectEnterEventArgs arg0)
    {
        if (!secondAreaInteracted)
        {
            secondAreaInteracted = true;
            secondAreaInteractedEvent?.Invoke();
            checkSecondRoomComplete();
        }
    }

    private void firstDoorInteracted(SelectEnterEventArgs arg0)
    {
        if (!secondAreaInteracted)
        {
            secondAreaInteracted = true;
            secondAreaInteractedEvent?.Invoke();
            checkSecondRoomComplete();
        }
    }

    private void redCubeInteracted(SelectEnterEventArgs arg0)
    {
        if (!firstAreaInteracted)
        {
            firstAreaInteracted = true;
            firstAreaInteractedEvent?.Invoke();
            checkSecondRoomComplete();
        }
    }

    private void blueCubeInteracted(SelectEnterEventArgs arg0)
    {
        if (!firstAreaInteracted)
        {
            firstAreaInteracted = true;
            firstAreaInteractedEvent?.Invoke();
            checkSecondRoomComplete();
        }
    }


    private void checkSecondRoomComplete()
    {
        if (firstAreaInteracted && secondAreaInteracted && thirdAreaInteracted)
        {
            challengeComplete();
            secondChallengeComplete?.Invoke();
        }
    }

    //third room methods

    private void setThirdRoomTriggers()
    {
        handsOfMidasParent.selectEntered.AddListener(handsOfMidasInteracted);

        cube1.selectEntered.AddListener(cube1Interacted);
        cube2.selectEntered.AddListener(cube2Interacted);
        cube3.selectEntered.AddListener(cube3Interacted);
        cube4.selectEntered.AddListener(cube4Interacted);

        button1.buttonPressed.AddListener(button1Interacted);
        button2.buttonPressed.AddListener(button2Interacted);
        button3.buttonPressed.AddListener(button3Interacted);
        button4.buttonPressed.AddListener(button4Interacted);
    }

    private void button4Interacted()
    {
        if (!thirdAreaR3Interacted)
        {
            thirdAreaR3Interacted = true;
            thirdAreaR3InteractedEvent?.Invoke();
            checkThirdRoomComplete();
        }
    }

    private void button3Interacted()
    {
        if (!thirdAreaR3Interacted)
        {
            thirdAreaR3Interacted = true;
            thirdAreaR3InteractedEvent?.Invoke();
            checkThirdRoomComplete();
        }
    }

    private void button2Interacted()
    {
        if (!thirdAreaR3Interacted)
        {
            thirdAreaR3Interacted = true;
            thirdAreaR3InteractedEvent?.Invoke();
            checkThirdRoomComplete();
        }
    }

    private void button1Interacted()
    {
        if (!thirdAreaR3Interacted)
        {
            thirdAreaR3Interacted = true;
            thirdAreaR3InteractedEvent?.Invoke();
            checkThirdRoomComplete();
        }
    }

    private void cube4Interacted(SelectEnterEventArgs arg0)
    {
        if (!secondAreaR3Interacted)
        {
            secondAreaR3Interacted = true;
            secondAreaR3InteractedEvent?.Invoke();
            checkThirdRoomComplete();
        }
    }

    private void cube3Interacted(SelectEnterEventArgs arg0)
    {
        if (!secondAreaR3Interacted)
        {
            secondAreaR3Interacted = true;
            secondAreaR3InteractedEvent?.Invoke();
            checkThirdRoomComplete();
        }
    }

    private void cube2Interacted(SelectEnterEventArgs arg0)
    {
        if (!secondAreaR3Interacted)
        {
            secondAreaR3Interacted = true;
            secondAreaR3InteractedEvent?.Invoke();
            checkThirdRoomComplete();
        }
    }

    private void cube1Interacted(SelectEnterEventArgs arg0)
    {
        if (!secondAreaR3Interacted)
        {
            secondAreaR3Interacted = true;
            secondAreaR3InteractedEvent?.Invoke();
            checkThirdRoomComplete();
        }
    }

    private void handsOfMidasInteracted(SelectEnterEventArgs arg0)
    {
        if (!firstAreaR3Interacted)
        {
            firstAreaR3Interacted = true;
            firstAreaR3InteractedEvent?.Invoke();
            checkThirdRoomComplete();
        }
    }


    private void checkThirdRoomComplete()
    {
        if (firstAreaR3Interacted && secondAreaR3Interacted && thirdAreaR3Interacted)
        {
            challengeComplete();
            thirdChallengeComplete?.Invoke();
        }
    }




    //general level stuff

    private void challengeComplete()
    {
        challengeNumber++;
    }


}

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

    private bool firstAreaInteracted = false;
    private bool secondAreaInteracted = false;
    private bool thirdAreaInteracted = false;

    public int challengeNumber = 0;

    //challenge events
    public UnityEvent firstChallengeComplete;
    public UnityEvent secondChallengeComplete;

    //area iteraction events
    public UnityEvent firstAreaInteractedEvent;
    public UnityEvent secondAreaInteractedEvent;
    public UnityEvent thirdAreaInteractedEvent;


    public UnityEvent thirdChallengeComplete;
    public UnityEvent fourthChallengeComplete;

    void Start()
    {
        if (firstRoomBoxTrigger != null)
        {
            setFirstRoomTrigger();
        }
        setSecondRoomTriggers();
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



    //general level stuff

    private void challengeComplete()
    {
        challengeNumber++;
    }


}

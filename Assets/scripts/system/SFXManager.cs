using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SFXManager : MonoBehaviour
{

    [Header("default audio source")]
    [SerializeField] AudioSource playerGrabAudioSource;
    [SerializeField] AudioSource backgroundMusicAudioSource;

    [Header("audio clips")]
    [SerializeField] AudioClip grabClip;

    XRGrabInteractable[] grabInteractables;

    [Header("Doors")]
    [SerializeField] AudioClip doorOpenClip;
    [SerializeField] AudioSource[] doorAudioSources;
    [SerializeField] DoorHingeInteractible[] doors;



    private void OnEnable()
    {
        setGrabbales();

        doors = FindObjectsByType<DoorHingeInteractible>(FindObjectsSortMode.None);
        if (doors.Length > 0)
        {
            doorAudioSources = new AudioSource[doors.Length];
            initializeDoors();
        }

    }

    private void initializeDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            DoorHingeInteractible currentDoor = doors[i];
            if (currentDoor != null)
            {
                doorAudioSources[i] = currentDoor.transform.AddComponent<AudioSource>();
                doorAudioSources[i].clip = doorOpenClip;
                currentDoor.selectEntered.AddListener(onDoorMove);
                currentDoor.selectExited.AddListener(onDoorStop);
            }
        }
    }

    private void onDoorStop(SelectExitEventArgs arg0)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            DoorHingeInteractible currentDoor = doors[i];
            if (currentDoor == arg0.interactableObject.transform.gameObject.GetComponent<DoorHingeInteractible>())
            {
                doorAudioSources[i].Stop();
            }
        }
    }

    private void onDoorMove(SelectEnterEventArgs arg0)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            DoorHingeInteractible currentDoor = doors[i];
            if (currentDoor == arg0.interactableObject.transform.gameObject.GetComponent<DoorHingeInteractible>())
            {
                doorAudioSources[i].Play();
            }
        }
    }

    private void setGrabbales()
    {
        grabInteractables = FindObjectsByType<XRGrabInteractable>(FindObjectsSortMode.None);
        foreach (var interactable in grabInteractables)
        {
            interactable.selectEntered.AddListener(onSelectGrabbable);
            interactable.selectExited.AddListener(onSelectExitGrabbable);
        }
    }

    private void onSelectExitGrabbable(SelectExitEventArgs arg0)
    {
        playGrabSound(grabClip);
    }

    private void onSelectGrabbable(SelectEnterEventArgs arg0)
    {
        playGrabSound(grabClip);
    }

    private void playGrabSound(AudioClip pAudioClip)
    {
        if (playerGrabAudioSource != null)
        {
            playerGrabAudioSource.clip = pAudioClip;
            playerGrabAudioSource.Play();
        }
    }
}

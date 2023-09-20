using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorSocketControll : XRSocketInteractor
{
    [SerializeField] GameObject key;
    public UnityEvent doorUnlocked;
    public UnityEvent doorLocked;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if(args.interactableObject.transform.gameObject == key)
        {
            doorUnlocked?.Invoke(); 
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if(args.interactableObject.transform.gameObject == key)
        {
            doorLocked?.Invoke(); 
        }
    }
}

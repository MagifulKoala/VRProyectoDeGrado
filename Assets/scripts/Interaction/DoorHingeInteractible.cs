using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHingeInteractible : SimpleHingeInteractible
{
    [SerializeField] Transform doorObject;
    [SerializeField] ComboLock comboLock;
    [SerializeField] XRSocketInteractor doorSocket; 

    [SerializeField] UnityEngine.Vector3 limitAngles = new UnityEngine.Vector3(0f, 0f, 0f);

    [SerializeField] Collider closedCollider;
    [SerializeField] Collider allOpenedCollider;

    [SerializeField] UnityEngine.Vector3 allOpenRotation;
    [SerializeField] bool useEndRotationClosed;
    [SerializeField] UnityEngine.Vector3 endRotationClosed;
    UnityEngine.Vector3 startRotation;


    private bool isAllOpened = false;
    private bool isClosed = false;

    float startAngleX;


    protected override void Start()
    {
        base.Start();

        startRotation = transform.localEulerAngles;
        startAngleX = startRotation.x;
        if (startAngleX >= 180)
        {
            startAngleX -= 360;
        }
        if (comboLock != null)
        {
            comboLock.unlockedAction += OnUnLocked;
            comboLock.lockedAction += OnLocked;
        }

    }

    private void OnLocked()
    {
        Debug.Log("OnLocked door hinge interactible called");
        OnLock();
    }

    private void OnUnLocked()
    {
        Debug.Log("OnUnLocked door hinge interactible called");
        UnLock();
    }



    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (doorObject != null)
        {
            doorObject.localEulerAngles = new UnityEngine.Vector3(
                doorObject.localEulerAngles.x,
                transform.localEulerAngles.y,
                doorObject.localEulerAngles.z
            );
        }



        if (isSelected)
        {
            //only called if the interactible is selected
            checkLimits();
        }


    }

    public void checkLimits()
    {
        isClosed = false;
        isAllOpened = false;
        float localAnglex = transform.localEulerAngles.x;

        if (localAnglex >= 180)
        {
            localAnglex -= 360;
        }

        if (localAnglex >= startAngleX + limitAngles.x || localAnglex <= startAngleX - limitAngles.x)
        {
            releaseHinge();

        }

    }

    public override void resetHinge()
    {
        Debug.Log("RESET HINGE CALLED");

        if (isClosed)
        {
            if (useEndRotationClosed)
            {
                transform.localEulerAngles = endRotationClosed; 
            }
            else
            {
                transform.localEulerAngles = startRotation;
            }
        }
        else if (isAllOpened)
        {
            transform.localEulerAngles = allOpenRotation;

        }
        else
        {
            transform.localEulerAngles = new UnityEngine.Vector3(
                startAngleX,
                transform.localEulerAngles.y,
                transform.localEulerAngles.z
            );
        }


    }


    private void OnTriggerEnter(Collider other)
    {

        if (other == closedCollider)
        {
            isClosed = true;
            releaseHinge();
        }
        else if (other == allOpenedCollider)
        {
            isAllOpened = true;
            releaseHinge();
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


//class is now inheriting from XRGrabInteractible
public class DrawerLock : XRGrabInteractable
{


    [SerializeField] Transform drawerTransform;
    [SerializeField] XRSocketInteractor keySocket;
    [SerializeField] bool isLocked; 
    [SerializeField] private UnityEngine.Vector3 limitDistances = new UnityEngine.Vector3 (0f,0f,0f);
    [SerializeField] private float upperLimmitZ = 0f; 


    private UnityEngine.Vector3 limitPosition;
    

    private Transform parentTransform;
    private const string defaultLayer = "Default"; 
    private const string grabLayer = "grab";

   
    //Vector3 positionLimit;
    //Vector3 maxRange = new Vector3(0f,0f,0f);
    bool isGrabed;


    void Start()
    {

        if(keySocket != null)
        {
            keySocket.selectEntered.AddListener(OnDrawerUnlocked);
            keySocket.selectExited.AddListener(OnDrawerLocked);
        }

        parentTransform = transform.parent.transform; 
        limitPosition = drawerTransform.localPosition; 
        
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        if(!isLocked)
        {
            isGrabed = true; 
            transform.SetParent(parentTransform); 
        }
        else
        {
            changeLayer(defaultLayer); 
        }

    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        isGrabed = false;
        changeLayer(grabLayer);
        transform.localPosition = drawerTransform.localPosition; 

    }

    private void changeLayer(string pLayer)
    {
        interactionLayers = InteractionLayerMask.GetMask(pLayer);
    }

    private void OnDrawerLocked(SelectExitEventArgs arg0)
    {
        isLocked = true; 
        Debug.Log("drawer LOCKED");
    }

    private void OnDrawerUnlocked(SelectEnterEventArgs arg0)
    {
        isLocked = false; 
        Debug.Log("drawer UN-LOCKED"); 
    }


    void Update()
    {
        if(isGrabed && drawerTransform != null)
        {
            drawerTransform.localPosition = new UnityEngine.Vector3(drawerTransform.localPosition.x, drawerTransform.localPosition.y, transform.localPosition.z);

            checkLimits();
        }
        
    }

    private void checkLimits()
    {
        if(transform.localPosition.x > limitPosition.x + limitDistances.x 
            || transform.localPosition.x < limitPosition.x - limitDistances.x
        )
        {
            changeLayer(defaultLayer);
        }
        else if(transform.localPosition.y > limitPosition.y + limitDistances.y 
            || transform.localPosition.y < limitPosition.y - limitDistances.y
        )
        {
            changeLayer(defaultLayer);
        }else if(transform.localPosition.z < limitPosition.z - limitDistances.z)
        {
            changeLayer(defaultLayer);
            drawerTransform.localPosition = limitPosition; 
        }else if(transform.localPosition.z > limitPosition.z + upperLimmitZ)
        {
            drawerTransform.localPosition = new UnityEngine.Vector3(drawerTransform.localPosition.x,
            drawerTransform.localPosition.y,
            limitPosition.z + upperLimmitZ
            );
        }
  
    }
}

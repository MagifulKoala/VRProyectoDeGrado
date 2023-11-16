using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class buttonControl : MonoBehaviour
{

    [SerializeField] float yUpperLimit; 
    [SerializeField] float yResetPosition; 
    private const string  BUTTON_TRIGGER = "buttonTrigger"; 
    public UnityEvent buttonPressed; 
    public UnityEvent buttonUnPressed; 
    private void Update()
    {
        checkLimits();    
    }

    private void checkLimits()
    {
        if(transform.localPosition.y > yUpperLimit)
        {
            transform.localPosition = new UnityEngine.Vector3(
                transform.localPosition.x,
                yResetPosition,
                transform.localPosition.z
            );
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name.Equals(BUTTON_TRIGGER))
        {
            Debug.Log("button pressed");
            buttonPressed?.Invoke();    
        }    
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.name.Equals(BUTTON_TRIGGER))
        {
            Debug.Log("button unpressed");
            buttonUnPressed?.Invoke();    
        }        
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ComboLock : MonoBehaviour
{

    [SerializeField] TMP_Text currentCombo; 
    [SerializeField] TMP_Text statusText; 
    [SerializeField] ButtonInteractible[] buttonInteractable;

    [SerializeField] Color lockedColor;
    [SerializeField] Color unLockedColor;

    [SerializeField] string password = "123";     

    string combinationText = ""; 


    public UnityAction unlockedAction; 
    private void OnUnlocked() => unlockedAction?.Invoke(); 


    public UnityAction lockedAction;
    private void OnLocked() => lockedAction?.Invoke(); 





    // Start is called before the first frame update
    void Start()
    {
        currentCombo.text = "000";

        lockCabinet();

        for (int i = 0; i < buttonInteractable.Length; i++)
        {
            buttonInteractable[i].selectEntered.AddListener(buttonPressed);
        }
    }



    private void buttonPressed(SelectEnterEventArgs arg0)
    {
        for (int i = 0; i < buttonInteractable.Length; i++)
        {
            if (arg0.interactableObject.transform.name == buttonInteractable[i].transform.name)
            {
                combinationText += "" + buttonInteractable[i].buttonValue;
                currentCombo.text = combinationText;
                if (combinationText.Length >= 3)
                {
                    checkCombination();
                }

            }
        }
    }

    private void checkCombination()
    {
       if(combinationText.Equals(password))
        {
            unlockCabinet();
        }
        else
       {
            lockCabinet(); 
       }
    }

    private void unlockCabinet()
    {
        statusText.text = "OPEN";
        statusText.color = unLockedColor;
        OnUnlocked(); 
    }

    private void lockCabinet()
    {
        statusText.text = "CLOSED";
        statusText.color = lockedColor;
        combinationText = "";
        currentCombo.text = "000"; 
        OnLocked(); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics.Contracts;

public class ButtonInteractible : XRSimpleInteractable
{
    // Start is called before the first frame update

    [SerializeField] Image imageButton;
    //[SerializeField] Color[] buttonColors = new Color[4];
    [SerializeField] Color normalColor;
    [SerializeField] Color highlightedColor;
    [SerializeField] Color pressedColor;
    [SerializeField] Color selectedColor;

    [SerializeField] public int buttonValue; 
    [SerializeField] public string specialValue; 

    [SerializeField] public bool displayNormalText; 



    //Color normalColor, highlightedColor, pressedColor, selectedColor; 

    bool isSelected = false; 

    void Start()
    {
        /*
        normalColor = buttonColors[0];
        highlightedColor = buttonColors[1];
        pressedColor = buttonColors[2];
        selectedColor = buttonColors[3];
        */
        if(specialValue != null && specialValue != "")
        {
            transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = specialValue.ToString(); 
        }
        else if(!displayNormalText)
        {
            transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = buttonValue.ToString(); 
        }
        


        imageButton.color = normalColor; 
    }


    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        isSelected = false; 
        imageButton.color = highlightedColor; 
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        if(!isSelected)
        {
            imageButton.color = normalColor; 
        }
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);


        isSelected = true;
        imageButton.color = pressedColor;

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        isSelected = false;
        imageButton.color = pressedColor;

    }


}

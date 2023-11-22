using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;

public class ButtonInteractible : XRSimpleInteractable
{
    [SerializeField] Image imageButton;

    [SerializeField] Color normalColor;
    [SerializeField] Color highlightedColor;
    [SerializeField] Color pressedColor;
    [SerializeField] Color selectedColor;

    [SerializeField] public int buttonValue;
    [SerializeField] public string specialValue;

    [SerializeField] public bool displayNormalText;

    bool buttonIsSelected = false;

    void Start()
    {
        if (specialValue != null && specialValue != "")
        {
            transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = specialValue.ToString();
        }
        else if (!displayNormalText)
        {
            transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = buttonValue.ToString();
        }


        if (imageButton != null)
        {
            imageButton.color = normalColor;
        }
    }


    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        buttonIsSelected = false;
        imageButton.color = highlightedColor;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        if (!buttonIsSelected)
        {
            imageButton.color = normalColor;
        }

    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);


        buttonIsSelected = true;
        imageButton.color = pressedColor;

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        buttonIsSelected = false;
        imageButton.color = pressedColor;

    }


}

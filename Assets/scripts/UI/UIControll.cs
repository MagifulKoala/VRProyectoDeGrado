using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class UIControll : MonoBehaviour
{

    [SerializeField] string[] strings;
    [SerializeField] TMP_Text[] textFields;
    [SerializeField] ButtonInteractible xrButton;
    [SerializeField] GameObject keyPointLight;

    [Obsolete]
    void Start()
    {
        if (textFields != null)
        {
            for (int i = 0; i < textFields.Length; i++)
            {
                textFields[i].text = strings[i];
            }
        }


        if (xrButton != null)
        {
            xrButton.onSelectEntered.AddListener(buttonPressed);
        }

    }

    int current = 1;

    private void buttonPressed(XRBaseInteractor arg0)
    {
        if(keyPointLight != null)
        {
            keyPointLight.SetActive(true);
        }
        

        Debug.Log("before if current: " + current);
        if (current > strings.Length - 1)
        {
            Debug.Log("enters if statment");
            current = 1;
        }
        textFields[0].text = strings[current];
        current += 1;
        Debug.Log(current);


    }


}

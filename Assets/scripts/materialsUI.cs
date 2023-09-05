using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class materialsUI : MonoBehaviour
{
    [SerializeField] TMP_Text materialText;
    
    public void changeText(string newText)
    {
        if(materialText != null)
        {
            materialText.text = newText;  
        }
        else
        {
            Debug.Log("material text is null");
        }
    }


}

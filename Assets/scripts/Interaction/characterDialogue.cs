using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class characterDialogue : MonoBehaviour
{
    
    [SerializeField] string[] textLines;
    [SerializeField] TMP_Text panelText;
    Timer dialogueTimer;
    [SerializeField] bool dialogueStarted = false; 
    int currentLine = 0; 
    float textChangeTime = 3f; 

    bool timerHasStarted = false; 

    void Start()
    {
        dialogueTimer = GetComponent<Timer>();
        dialogueTimer.setTotalTime(textChangeTime);
    }

    void Update()
    {
        if(dialogueStarted)
        {
            changePanelText(textLines[currentLine]); 
            if(!timerHasStarted)
            {
            dialogueTimer.startTimer();
            timerHasStarted = true; 
            }
            if(dialogueTimer.timerHasFinished)
            {
                timerHasStarted = false; 
                if(currentLine < textLines.Length)
                {
                    currentLine++;
                }
                else
                {
                    currentLine = 0;
                    dialogueStarted = false; 
                }
                
            }
        }

    }

    private void startDialogue()
    {
        dialogueStarted = true; 
    }

    private void changePanelText(string pNewText)
    {
        panelText.text = pNewText; 
    }


}

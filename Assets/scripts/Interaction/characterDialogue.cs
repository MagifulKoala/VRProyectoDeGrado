using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class characterDialogue : MonoBehaviour
{
    
    [SerializeField] string[] textLines;
    [SerializeField] TMP_Text panelText;
    [SerializeField] public bool dialogueStarted = false; 
    Timer dialogueTimer;
    int currentLine = 0; 
    float textChangeTime = 3f; 
    bool timerHasStarted = false; 
    bool hasPlayed = false;
    public UnityEvent dialogueEndedEvent; 
    public UnityEvent dialogueStartedEvent; 

    void Start()
    {
        dialogueTimer = GetComponent<Timer>();
        dialogueTimer.setTotalTime(textChangeTime);
    }

    void Update()
    {
        if(dialogueStarted && !hasPlayed)
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
                if(currentLine < textLines.Length - 1)
                {
                    currentLine++;
                }
                else
                {
                    currentLine = 0;
                    dialogueStarted = false; 
                    changePanelText("");
                    dialogueEndedEvent?.Invoke(); 
                    hasPlayed = true; 
                }
                
            }
        }

    }

    public void startDialogue()
    {
        dialogueStarted = true; 
        //dialogueStartedEvent?.Invoke(); 
    }

    private void changePanelText(string pNewText)
    {
        panelText.text = pNewText; 
    }


}

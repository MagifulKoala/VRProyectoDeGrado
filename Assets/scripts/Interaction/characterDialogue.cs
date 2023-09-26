using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class characterDialogue : MonoBehaviour
{

    [Header("Initial dialogue")]
    [SerializeField] string[] initialTextLines;
    [Header("trigger dialogue")]
    [SerializeField] string[] triggeredTextLines;
    [Header("other")]
    [SerializeField] TMP_Text panelText;
    [SerializeField] public bool initialDialogueStarted = false;
    [SerializeField] public bool triggeredDialogueStarted = false;
    Timer dialogueTimer;
    int currentLine = 0;
    float textChangeTime = 3f;
    bool timerHasStarted = false;
    bool hasPlayed = false;
    public UnityEvent dialogueEndedEvent;
    public UnityEvent dialogueStartedEvent;
    public UnityEvent triggerDialogueEndedEvent;
    

    void Start()
    {
        dialogueTimer = GetComponent<Timer>();
        dialogueTimer.setTotalTime(textChangeTime);
    }

    void Update()
    {
        if (initialDialogueStarted && !hasPlayed)
        {
            startDialogue(initialTextLines);
        }
        else if (triggeredDialogueStarted)
        {
            startDialogue(triggeredTextLines);
        }

    }

    private void startDialogue(string[] textLines)
    {
        changePanelText(textLines[currentLine]);
        if (!timerHasStarted)
        {
            dialogueTimer.startTimer();
            timerHasStarted = true;
        }
        if (dialogueTimer.timerHasFinished)
        {
            timerHasStarted = false;
            if (currentLine < textLines.Length - 1)
            {
                currentLine++;
            }
            else
            {
                currentLine = 0;
                initialDialogueStarted = false;
                triggeredDialogueStarted = false;
                changePanelText("");
                dialogueEndedEvent?.Invoke();
                if(textLines == triggeredTextLines)
                {
                    triggerDialogueEndedEvent?.Invoke(); 
                }
                hasPlayed = true;
            }

        }
    }

    public void triggerDialogue(string pDialogue)
    {
        if (pDialogue.Equals("initial"))
        {
            initialDialogueStarted = true;
        }
        else if (pDialogue.Equals("triggered"))
        {
            triggeredDialogueStarted = true;
        }

    }

    private void changePanelText(string pNewText)
    {
        panelText.text = pNewText;
    }


}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class characterDialogue : MonoBehaviour
{

    [Header("Initial dialogue")]
    [TextArea(3, 10)]
    [SerializeField] string[] initialTextLines;
    [Header("trigger dialogue")]
    [TextArea(3, 10)]
    [SerializeField] string[] triggeredTextLines;
    [Header("Final Dialogue")]
    [TextArea(3,10)]
    [SerializeField] string[] finalTextLines; 

    [Header("other")]

    [Header("dialogue list")]
    [SerializeField] string[,] characterDialogueList;
    [SerializeField] TMP_Text panelText;
    [SerializeField] public bool initialDialogueStarted = false;
    [SerializeField] public bool triggeredDialogueStarted = false;
    public bool triggerEndDialogue = false; 
    Timer dialogueTimer;
    int currentLine = 0;
    float textChangeTime = 3f;
    bool timerHasStarted = false;
    bool hasPlayed = false;
    bool checkPointReached = false;
    bool startedWriting = false;
    bool challengeComplete = false;
    int currentDialogue = 0;
    public UnityEvent dialogueEndedEvent;
    public UnityEvent dialogueStartedEvent;
    public UnityEvent triggerDialogueEndedEvent;
    public UnityEvent finalDialogueEndedEvent; 


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
        else if(triggerEndDialogue)
        {
            startDialogue(finalTextLines);
        }

    }

    public void completeChallenge()
    {
        challengeComplete = true; 
        currentDialogue++; 
    }
        

    private void startDialogue(string[] textLines)
    {
        if (!checkPointReached)
        {
            changePanelText(textLines[currentLine]);
            //Debug.Log(startedWriting);
            /*             if (!startedWriting)
                        {
                            Debug.Log(textLines[currentLine]);
                            startedWriting = true; 
                            StopAllCoroutines();
                            StartCoroutine(typeLine(textLines[currentLine]));
                        } */
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
                    if (textLines[currentLine].Equals("***CHECKPOINT***"))
                    {
                        checkPointReached = true;
                        currentLine++;
                    }
                }
                else
                {
                    currentLine = 0;

                    initialDialogueStarted = false;
                    triggeredDialogueStarted = false;
                    triggerEndDialogue = false; 

                    changePanelText("");
                    dialogueEndedEvent?.Invoke();
                    finalDialogueEndedEvent?.Invoke(); 
                    if (textLines == triggeredTextLines)
                    {
                        triggerDialogueEndedEvent?.Invoke();
                    }
                    hasPlayed = true;
                }

            }
        }

    }

    public void progressCheckPoint()
    {
        checkPointReached = false;
    }

    public void triggerDialogue(string pDialogue)
    {
        //Debug.Log("current dialogue " + currentDialogue);

        switch (currentDialogue)
        {
            case 0:
                initialDialogueStarted = true;
                break;
            case 1:
                triggeredDialogueStarted = true;
                break;
            case 2:
                triggerEndDialogue = true; 
                break;
        }

        currentDialogue++;
        if(!challengeComplete)
        {
            if(currentDialogue > 1)
            {
                currentDialogue = 1;
            }
        }
        else
        {
            if(currentDialogue > 2)
            {
                currentDialogue = 2; 
            }
        }

    }

    private void changePanelText(string pNewText)
    {
        panelText.text = pNewText;
    }

    IEnumerator typeLine(string pLine)
    {
        Debug.Log(pLine);
        panelText.text = "";
        foreach (var c in pLine.ToCharArray())
        {
            panelText.text += c;
            float typeSpeed = dialogueTimer.totalTime / (pLine.ToCharArray().Length);
            //float typeSpeed = 0.15f;
            yield return new WaitForSeconds(typeSpeed);
        }
        startedWriting = false;
    }


}

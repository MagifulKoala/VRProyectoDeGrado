using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class characterDialogue : MonoBehaviour
{

    [Header("Initial dialogue")]
    [TextArea(3,10)]
    [SerializeField] string[] initialTextLines;
    [Header("trigger dialogue")]
    [TextArea(3,10)]
    [SerializeField] string[] triggeredTextLines;
    [Header("other")]

    [Header("dialogue list")]
    [SerializeField] string[,] characterDialogueList;
    [SerializeField] TMP_Text panelText;
    [SerializeField] public bool initialDialogueStarted = false;
    [SerializeField] public bool triggeredDialogueStarted = false;
    Timer dialogueTimer;
    int currentLine = 0;
    float textChangeTime = 3f;
    bool timerHasStarted = false;
    bool hasPlayed = false;
    bool checkPointReached = false;
    bool startedWriting = false;
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
                    changePanelText("");
                    dialogueEndedEvent?.Invoke();
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

    IEnumerator typeLine(string pLine)
    {
        Debug.Log(pLine);
        panelText.text = ""; 
        foreach (var c in pLine.ToCharArray())
        {
            panelText.text += c;
            float typeSpeed = dialogueTimer.totalTime/(pLine.ToCharArray().Length);
            //float typeSpeed = 0.15f;
            yield return new WaitForSeconds(typeSpeed);
        }
        startedWriting = false; 
    }


}

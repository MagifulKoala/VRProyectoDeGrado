using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class wizardDialogue : MonoBehaviour
{

    [Header("Initial dialogue")]
    [TextArea(3, 10)]
    [SerializeField] string[] initialTextLines;
    [Header("Final dialogue")]
    [TextArea(3, 10)]
    [SerializeField] string[] finalTextLines;
    [SerializeField] TMP_Text panelText;
    Timer dialogueTimer;
    int currentLine = 0;
    float textChangeTime = 10f;
    bool timerHasStarted = false;
    bool isPlaying = false;
    public bool wizardExposed = false; 
    public bool firstChallengeComplete = false; 

    public void setWizardExposed(bool value)
    {
        wizardExposed = value;
    }

    public void firstComplete(bool value)
    {
        firstChallengeComplete = value;
    }


    void Start()
    {
        dialogueTimer = GetComponent<Timer>();
        dialogueTimer.setTotalTime(textChangeTime);
    }


    void Update()
    {
        if(!isPlaying)
        {
            if(wizardExposed)
            {
                startDialogue(finalTextLines);
            }
            else if(firstChallengeComplete)
            {
                startDialogue(initialTextLines);
            }
        }
    }



    private void startDialogue(string[] textLines)
    {

        //isPlaying = true;
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
                changePanelText("");
                isPlaying = false;
            }

        }
    }


    private void changePanelText(string pNewText)
    {
        panelText.text = pNewText;
    }


}

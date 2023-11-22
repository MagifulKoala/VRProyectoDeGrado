using UnityEngine;
using UnityEngine.Events;

public class NPCControll : MonoBehaviour
{

    Animator npcAnimator;
    private const string playerTag = "Player";
    private const string conditionPlayerEntered = "playerEntered";
    private const string conditionDialogueFinished = "dialogueFinished";
    private const string idle = "idle";
    bool hasPlayed = false;
    public UnityEvent playerFirstDetectedEvent;
    public UnityEvent playerDetectedEvent;
    public UnityEvent playerExitedEvent;


    private void Start()
    {
        npcAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag.Equals(playerTag))
        {
            playerDetectedEvent?.Invoke();
            if (!hasPlayed)
            {
                playerFirstDetectedEvent?.Invoke();
                hasPlayed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals(playerTag))
        {
            playerExitedEvent?.Invoke(); 
        }
    }

    public void setAnimationGreet()
    {
        npcAnimator.SetBool(conditionPlayerEntered, true);
    }

    public void setAnimationOfferKey()
    {
        npcAnimator.SetBool(conditionDialogueFinished, true);
    }

    public void setAnimationIdle()
    {
        npcAnimator.SetBool(idle, true);
    }
}

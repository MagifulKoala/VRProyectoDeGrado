using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handGrabAnimation : MonoBehaviour
{
    Animator animator;
    private const string grabBool = "isGrabbing";
    private const string pointBool = "isPointing";
    bool handIsGrabbing = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void triggerGrabHandAnimation()
    {
        if (!handIsGrabbing)
        {
            Debug.Log("triggerhandANim");
            animator.SetBool(grabBool, true);
            handIsGrabbing = true;
        }

    }

    public void stopHandGrabAnimation()
    {
        Debug.Log("trigger stop anim");
        animator.SetBool(grabBool, false);
        handIsGrabbing = false;
    }

    public void startPointAnimation()
    {
        animator.SetBool(pointBool, true);
    }

    public void stopPointAnimtion()
    {
        animator.SetBool(pointBool, false);
    }
}

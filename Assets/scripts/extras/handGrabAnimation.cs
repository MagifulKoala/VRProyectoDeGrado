using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        //Debug.Log("animator: " + animator + "  object: " + gameObject);
    }

    public void startGrabHandAnimation()
    {
        if (!handIsGrabbing && animator != null)
        {
            //Debug.Log("triggerhandANim");
            //Debug.Log("animator:" + animator is null);
            //Debug.Log(animator);
            animator.SetBool(grabBool, true);
            handIsGrabbing = true;
        }

    }

    public void stopHandGrabAnimation()
    {
        if (animator != null)
        {
            //Debug.Log("trigger stop anim");
            animator.SetBool(grabBool, false);
            handIsGrabbing = false;
        }
    }

    public void startPointAnimation()
    {
        if (animator != null)
        {
            animator.SetBool(pointBool, true);
        }
    }

    public void stopPointAnimtion()
    {
        if (animator != null)
        {
            animator.SetBool(pointBool, false);
        }
    }
}

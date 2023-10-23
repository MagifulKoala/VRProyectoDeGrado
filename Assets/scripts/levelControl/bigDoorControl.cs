using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigDoorControl : MonoBehaviour
{

   [SerializeField] bool doorOpen;
   [SerializeField] bool doorClosed;
   public Animator bigDoorAnimator;
   public const string OPEN_DOOR = "OpenDoor";
   public const string CLOSE_DOOR = "CloseDoor";



   private void Start()
   {
    bigDoorAnimator = GetComponent<Animator>(); 
   }

   private void Update()
   {
      if(doorOpen)
      {
         openDoor();
      }
      else if(doorClosed)
      {
         closeDoor(); 
      }

   }

   public void openDoor()
   {
    bigDoorAnimator.SetBool(OPEN_DOOR, true);
   }
   public void closeDoor()
   {
    bigDoorAnimator.SetBool(CLOSE_DOOR, true);
   }
}

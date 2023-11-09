using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardWallControl : MonoBehaviour
{

   [SerializeField] bool doorOpen;
   [SerializeField] bool doorClosed;
   public Animator wizardDoorAnim;
   public const string OPEN_DOOR = "openWizardWall";




   private void Start()
   {
    wizardDoorAnim = GetComponent<Animator>(); 
   }

   private void Update()
   {
      if(doorOpen)
      {
         openDoor();
      }
   }

   public void openDoor()
   {
    wizardDoorAnim.SetBool(OPEN_DOOR, true);
   }
}

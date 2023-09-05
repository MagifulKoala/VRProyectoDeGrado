using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandMaterials : XRDirectInteractor
{

 
    [SerializeField] GameObject leftHandMaterials; 



    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        //Debug.Log(args.interactableObject.transform.gameObject);
        ObjectControll currentObjControl = args.interactable.transform.gameObject.GetComponent<ObjectControll>(); 

        if(currentObjControl != null)
        {
            if(leftHandMaterials != null)
            {
                currentObjControl.changeMaterial(leftHandMaterials.GetComponent<LeftHandMaterials>().getLeftHandMaterial()); 
            }
        }
        else
        {
            Debug.Log("ObjectControll = null"); 
        }

    }



}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftHandMaterials : XRDirectInteractor
{

    [SerializeField] GameObject rightHand; 
    [SerializeField] GameObject leftHand; 
    public GameObject currentMaterial = null; 

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        //Debug.Log(args.interactableObject.transform.gameObject);
        ObjectControll currentObjectController = args.interactable.transform.gameObject.GetComponent<ObjectControll>(); 

        if(currentObjectController != null)
        {
            currentMaterial = currentObjectController.getMaterial();

            leftHand.GetComponent<ObjectControll>().changeMaterial(currentMaterial);
            rightHand.GetComponent<ObjectControll>().changeMaterial(currentMaterial);
        }
        else
        {
            Debug.Log("CubeController = null"); 
        }

    }


    public GameObject getLeftHandMaterial()
    {
        return currentMaterial; 
    }

}

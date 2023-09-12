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

        if (currentObjControl != null)
        {
            if (leftHandMaterials != null)
            {
                GameObject newMaterial = leftHandMaterials.GetComponent<LeftHandMaterials>().getLeftHandMaterial();
                if (newMaterial.name == "explosive")
                {
                    currentObjControl.changeMaterialSpecial(newMaterial);
                }
                else
                {
                    currentObjControl.changeMaterial(newMaterial);
                }

            }
        }
        else
        {
            Debug.Log("ObjectControll = null");
        }

    }



}

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandMaterials : XRDirectInteractor
{


    [SerializeField] GameObject leftHandMaterials;

    [System.Obsolete]
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
                    if (currentObjControl.initializeMaterialInChildren)
                    {
                        currentObjControl.changeMaterialInChildren(newMaterial);
                    }
                }
                else if (currentObjControl.initializeMaterialInChildren)
                {
                    currentObjControl.changeMaterialInChildren(newMaterial);
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

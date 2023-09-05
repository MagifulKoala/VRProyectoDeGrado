using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketMaterial : XRSocketInteractor
{
    [SerializeField] GameObject uiMaterialsCanvas;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        string materialInSocket = args.interactableObject.transform.gameObject.GetComponent<ObjectControll>().getMaterial().transform.name; 

        uiMaterialsCanvas.GetComponent<materialsUI>().changeText(materialInSocket); 
    }

}

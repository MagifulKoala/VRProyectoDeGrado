using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectController : MonoBehaviour
{
    [SerializeField] public GameObject material;
    [SerializeField] GameObject[] materials;

    MeshRenderer objectMeshRenderer;
    public materialController materialCtrl;
    protected virtual void Start()
    {
        objectMeshRenderer = GetComponent<MeshRenderer>();


        if (material != null)
        {
            materialCtrl = material.GetComponent<materialController>();
            objectMeshRenderer.material = materialCtrl.materialVisualMaterial;
        }
        else
        {
            Debug.Log("material has not been assigned");
        }
        /*
        foreach (var item in materials)
        {

            if (item.Equals(material))
            {
                materialController materialCtr = item.GetComponent<materialController>();
                objectMeshRenderer.material = materialCtr.materialVisualMaterial;
                material = item;

            }
        }
        */

    }

    public void changeMaterial(GameObject pNewMaterial)
    {
        foreach (var item in materials)
        {


            if (item.Equals(pNewMaterial))
            {
                materialController materialControl = pNewMaterial.GetComponent<materialController>();

                objectMeshRenderer.material = materialControl.materialVisualMaterial;
                materialCtrl = materialControl; 
                material = item;
            }
        }

    }

    public GameObject getMaterial()
    {
        return material;
    }
}
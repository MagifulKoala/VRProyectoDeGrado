using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectController : MonoBehaviour
{
    [SerializeField] public GameObject material;
    [SerializeField] GameObject[] materials;

    MeshRenderer objectMeshRenderer;
    SkinnedMeshRenderer skinnedMeshRenderer;
    public materialController materialCtrl;
    protected virtual void Start()
    {
        objectMeshRenderer = GetComponent<MeshRenderer>();
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();


        if (material != null)
        {
            materialCtrl = material.GetComponent<materialController>();
            if (objectMeshRenderer != null)
            {
                objectMeshRenderer.material = materialCtrl.materialVisualMaterial;
            }
            else if (skinnedMeshRenderer != null)
            {
                skinnedMeshRenderer.material = materialCtrl.materialVisualMaterial;
            }


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

                if (objectMeshRenderer != null)
                {
                    objectMeshRenderer.material = materialControl.materialVisualMaterial;
                }
                else if (skinnedMeshRenderer != null)
                {
                    skinnedMeshRenderer.material = materialControl.materialVisualMaterial;
                }

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectController : MonoBehaviour
{
    [SerializeField] public GameObject material;
    [SerializeField] GameObject[] materials;
    [SerializeField] public bool initializeMaterialInChildren;
    [SerializeField] bool dontInitializeMaterial = false;

    MeshRenderer objectMeshRenderer;
    SkinnedMeshRenderer skinnedMeshRenderer;
    public materialController materialCtrl;
    protected virtual void Start()
    {
        objectMeshRenderer = GetComponent<MeshRenderer>();
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();


        if (!dontInitializeMaterial)
        {
            if (material != null)
            {
                materialCtrl = material.GetComponent<materialController>();
                if (objectMeshRenderer != null)
                {
                    if (objectMeshRenderer.materials.Length > 1)
                    {
                        objectMeshRenderer.materials =
                        initializeVisualMaterialList(objectMeshRenderer.materials, materialCtrl.materialVisualMaterial);
                    }
                    else
                    {
                        objectMeshRenderer.material = materialCtrl.materialVisualMaterial;
                    }
                }
                else if (skinnedMeshRenderer != null)
                {
                    skinnedMeshRenderer.material = materialCtrl.materialVisualMaterial;
                }
                else if (initializeMaterialInChildren)
                {
                    changeMaterialInChildren(material);
                }
            }
            else
            {
                Debug.Log("material has not been assigned");
            }
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
                    if (objectMeshRenderer.materials.Length > 1)
                    {
                        objectMeshRenderer.materials =
                        initializeVisualMaterialList(objectMeshRenderer.materials, materialControl.materialVisualMaterial);
                    }
                    else
                    {
                        objectMeshRenderer.material = materialControl.materialVisualMaterial;
                    }
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

    public void changeMaterial(GameObject pNewMaterial, GameObject pObject)
    {
        //Debug.Log("change New Material invoked" + " " + pNewMaterial + " object: " + pObject);

        MeshRenderer newObjectMeshRenderer = pObject.GetComponent<MeshRenderer>();
        SkinnedMeshRenderer newSkinnedMeshRender = pObject.GetComponent<SkinnedMeshRenderer>();

        foreach (var item in materials)
        {
            if (item.Equals(pNewMaterial))
            {
                materialController materialControl = pNewMaterial.GetComponent<materialController>();

                if (newObjectMeshRenderer != null)
                {
                    newObjectMeshRenderer.material = materialControl.materialVisualMaterial;
                }
                else if (newSkinnedMeshRender != null)
                {
                    newSkinnedMeshRender.material = materialControl.materialVisualMaterial;
                }

                materialCtrl = materialControl;
                material = item;
            }
        }

    }

    public void changeMaterialInChildren(GameObject pNewMaterial)
    {
        foreach (Transform child in transform)
        {
            changeMaterial(pNewMaterial, child.gameObject);
        }
    }

    public Material[] initializeVisualMaterialList(Material[] pMaterialList, Material pMaterial)
    {
        for (int i = 0; i < pMaterialList.Length; i++)
        {
            pMaterialList[i] = pMaterial;
        }

        return pMaterialList;
    }

    public GameObject getMaterial()
    {
        return material;
    }
}
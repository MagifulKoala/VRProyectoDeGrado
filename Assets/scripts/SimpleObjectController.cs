using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectController : MonoBehaviour
{
    [SerializeField] public GameObject material;
    [SerializeField] GameObject[] materials; 

    MeshRenderer objectMeshRenderer;
    protected virtual void Start()
    {
        objectMeshRenderer = GetComponent<MeshRenderer>(); 
        

        foreach (var item in materials)
        {
           
            if(item.Equals(material))
            {
                materialController materialCtr = item.GetComponent<materialController>();
                objectMeshRenderer.material = materialCtr.materialVisualMaterial; 
                material = item; 
                
            }
        }

    }

    public void changeMaterial(GameObject pNewMaterial)
    {
        foreach (var item in materials)
        {
            

            if(item.Equals(pNewMaterial))
            {
                materialController materialControl = pNewMaterial.GetComponent<materialController>(); 

                objectMeshRenderer.material = materialControl.materialVisualMaterial; 
                material = item; 
            }
        }
        
    }

    public GameObject getMaterial()
    {
        return material; 
    }
}
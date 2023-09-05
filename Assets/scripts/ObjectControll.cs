using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControll : MonoBehaviour
{
    [SerializeField] GameObject material;
    [SerializeField] GameObject[] materials; 

    MeshRenderer objectMeshRenderer;
    private void Start()
    {
        objectMeshRenderer = GetComponent<MeshRenderer>(); 
        

        foreach (var item in materials)
        {
           
            if(item.Equals(material))
            {
                materialController materialCtr = item.GetComponent<materialController>();
                objectMeshRenderer.material = materialCtr.materialVisualMaterial; 
                material = item; 
        
               /*
                if(transform.name == "left hand")
                {
                    Debug.Log("material set on :" + transform.name + "  " + item); 
                }
                */ 
                
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
        
               /*
                if(transform.name == "left hand")
                {
                    Debug.Log("material set on :" + transform.name + "  " + item); 
                }
                */ 
                
            }
        }
        
    }

    public GameObject getMaterial()
    {
        return material; 
    }
}

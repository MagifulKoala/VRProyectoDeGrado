using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveMaterial : MonoBehaviour
{
    [SerializeField] float explosiveForce = 200f;
    [SerializeField] float finalExplosionSize = 3f;
    [SerializeField] float explosionExpansionRate = 1f; 
    [SerializeField] float explosionTimer = 5f; 
    [SerializeField] bool explosionTriggered = false; 
    ObjectControll parentObjectControll; 
    SphereCollider sphereCollider;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();    
        if(transform.parent != null)
        {
            parentObjectControll = transform.parent.GetComponent<ObjectControll>();
            parentObjectControll.ExplosionTriggered.AddListener(generateExplosion);  
        }
    }


    private void Update()
    {
        if(explosionTriggered)
        {
            Debug.Log("BOOOM");
            Destroy(transform.parent,0); 
        }
  
    }

    private void generateExplosion()
    {
      explosionTriggered = true; 
    }

 


}

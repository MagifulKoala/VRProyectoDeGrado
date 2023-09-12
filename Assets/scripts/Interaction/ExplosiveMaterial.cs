using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveMaterial : MonoBehaviour
{
    [SerializeField] ParticleSystem explosiveParticleSystem; 
    [SerializeField] float explosiveForce = 200f;
    [SerializeField] float finalExplosionSize = 3f;
    [SerializeField] float explosionExpansionRate = 1f; 
    [SerializeField] float explosionTime = 5f; 
    [SerializeField] bool explosionTriggered = false; 
    ObjectControll parentObjectControll; 
    SphereCollider sphereCollider;
    Timer timer; 

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();    
        timer = GetComponent<Timer>();
        if(transform.parent != null)
        {
            parentObjectControll = transform.parent.GetComponent<ObjectControll>();
            parentObjectControll.ExplosionTriggered.AddListener(generateExplosion);  
        }
        if(timer != null)
        {
            timer.setTotalTime(explosionTime); 
        }
    }


    private void Update()
    {
        if(explosionTriggered)
        {
            Debug.Log("BOOOM");
            explosionTriggered = false;
            Destroy(transform.parent.gameObject,0); 
        }
  
    }

    private void generateExplosion()
    {
      explosionTriggered = true; 
    }

 


}

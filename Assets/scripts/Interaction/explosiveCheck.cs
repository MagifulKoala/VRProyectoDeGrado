using UnityEngine;
using UnityEngine.Events;

public class explosiveCheck : MonoBehaviour
{

    public UnityEvent explosionDetected; 
    Collider currentExplosive; 
    private void OnTriggerEnter(Collider other)
    {
        ObjectControll objControl = other.gameObject.GetComponent<ObjectControll>();
        if (objControl != null)
        {
            if (objControl.material.name.Equals("explosive"))
            {
                currentExplosive = other; 
                //currentExplosive.gameObject.GetComponent<ObjectControll>().GetComponentInChildren<ExplosiveMaterial>().ObjectDestroyed.AddListener(objExploded); 
                currentExplosive.gameObject.GetComponentInChildren<ExplosiveMaterial>().ObjectDestroyed.AddListener(objExploded); 
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other == currentExplosive)
        {
            currentExplosive.gameObject.GetComponent<ObjectControll>().GetComponentInChildren<ExplosiveMaterial>().ObjectDestroyed.RemoveListener(objExploded);
            currentExplosive = null; 
        }    
    }

    private void objExploded()
    {
        explosionDetected?.Invoke(); 
    }
}

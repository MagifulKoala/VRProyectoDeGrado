using UnityEngine;
using UnityEngine.Events;

public class boxTrigger : MonoBehaviour
{
   public UnityEvent triggerEntered;

    private void OnTriggerEnter(Collider other)
    {
        triggerEntered?.Invoke();     
    }
}

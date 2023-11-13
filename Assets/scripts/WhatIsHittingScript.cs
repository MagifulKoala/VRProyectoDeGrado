using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject gazeInteractorObject;
    // Start is called before the first frame update
    void Start()
    {
       
        Vector3 gazeOrigin = gazeInteractorObject.transform.position;
        Vector3 gazeDirection = gazeInteractorObject.transform.forward;
    }

    // Update is called once per frame


    // Assuming your gaze interactor object is assigned to this variable

    // Get the gaze origin and direction from the object


    void Update()
    {

        Vector3 gazeOrigin = gazeInteractorObject.transform.position;
        Vector3 gazeDirection = gazeInteractorObject.transform.forward;

        Ray ray = new Ray(gazeOrigin, gazeDirection);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Clicked on " + hit.transform.name);
        }
        else
        {
            Debug.Log("Nothing hit");
        }
    }
}

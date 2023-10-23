using UnityEngine;
using System.Collections;

public class FallOnTouch : MonoBehaviour
{
    // Reference to the Rigidbody component
    private Rigidbody rb;

    private MeshRenderer meshRenderer;

    // Reference to the new material you want to apply
    public Material newMaterial; // Assign this in the Unity Editor


    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();

        meshRenderer = GetComponent<MeshRenderer>();

        // Disable gravity initially
        rb.useGravity = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the trigger collider belongs to the object you want to activate gravity on
        
            // Activate gravity
            rb.useGravity = true;
            meshRenderer.materials[0] = newMaterial;

    }
}
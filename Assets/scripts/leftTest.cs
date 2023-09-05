using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftTest : MonoBehaviour
{
    
    MeshRenderer meshRenderer;
    [SerializeField] Material other;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = other; 
    }


}

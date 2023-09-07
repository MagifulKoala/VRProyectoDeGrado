using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class materialController : MonoBehaviour
{
    //how the material looks like
    [SerializeField] public Material materialVisualMaterial;


    //physics attributes
    [SerializeField] public float gravity = 1f;
    [SerializeField] public float bouyancy = 1f;
    [SerializeField] public float mass = 1f;

    //extra attributes
    [SerializeField] public bool isFlammable = false;
    [SerializeField] public bool onFire = false;
    [SerializeField] public bool explosive = false;
    [SerializeField] public bool canMelt = false;
    [SerializeField] public bool canBreak = false;
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject followCamera;
    void Update()
    {
        transform.localEulerAngles = new UnityEngine.Vector3(
          transform.localEulerAngles.x,
          followCamera.transform.localEulerAngles.y,
          transform.localEulerAngles.z
        );
    }
}

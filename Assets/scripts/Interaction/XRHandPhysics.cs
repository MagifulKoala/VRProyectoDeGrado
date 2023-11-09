using UnityEngine;

public class XRHandPhysics : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    private SphereCollider handCollider;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        handCollider = GetComponentInChildren<SphereCollider>();
    }

    public void toggleHandCollider(bool pState)
    {
        if (handCollider != null)
        {
            handCollider.enabled = pState;
        }
    }

    public void enabledHandCollider()
    {
        toggleHandCollider(true);
    }

    public void toggleHandColliderDelay(float pDelay)
    {
        Invoke("enabledHandCollider", pDelay);
    }

    private void FixedUpdate()
    {
        rb.velocity = (followTarget.position - transform.position) / Time.fixedDeltaTime;
        //Debug.Log("follow target:" + followTarget.position + " currentPos: " + transform.position + "vel: " + rb.velocity);

        UnityEngine.Quaternion rotationDifference = followTarget.rotation * UnityEngine.Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out UnityEngine.Vector3 rotationAxis);

        UnityEngine.Vector3 rotationDifferenceDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }

}

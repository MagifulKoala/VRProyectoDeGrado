using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class SimpleHingeInteractible : XRSimpleInteractable
{
    private Transform grabHand;
    [SerializeField] bool isLocked;

    private Collider hingeCollider;
    private UnityEngine.Vector3 hingePositions;

    [SerializeField] private float magnitudeLimtis = 0.259f;

    public const string defaultLayer = "Default";
    public const string grabLayer = "grab";

    protected virtual void Start()
    {
        hingeCollider = GetComponent<Collider>();
    }
    //allows children to override this method and then call the base update
    protected virtual void Update()
    {
        if (grabHand != null)
        {
            trackHand();
        }
    }

    private void trackHand()
    {
        transform.LookAt(grabHand, transform.forward);
        hingePositions = hingeCollider.bounds.center;

        UnityEngine.Vector3 distanceVector = grabHand.transform.position - hingePositions;

        if (distanceVector.magnitude >= magnitudeLimtis)
        {
            releaseHinge();
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (isLocked == false)
        {
            grabHand = args.interactorObject.transform;
        }


    }


    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        grabHand = null;
        changeLayer(grabLayer);
        resetHinge();
    }


    public void UnLock()
    {
        //Debug.Log("UnLock simpleHinge Interactible called");
        isLocked = false;
    }

    public void OnLock()
    {
        isLocked = true;
    }


    public void releaseHinge()
    {
        changeLayer(defaultLayer);
        if (grabHand == null)
        {
            Debug.Log("fail-safe activated");
            resetHinge();
            changeLayer(grabLayer);
        }
    }

    public void changeLayer(string pLayer)
    {
        interactionLayers = InteractionLayerMask.GetMask(pLayer);
    }


    public abstract void resetHinge();
}

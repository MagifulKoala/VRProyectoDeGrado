using UnityEngine;

public class spawnerControl : MonoBehaviour
{
    [SerializeField] GameObject objectInstance;
    [SerializeField] int maxNumber;
    [SerializeField] bool disableMaxCount;
    [SerializeField] bool forceSpawn;

    [SerializeField] GameObject lastInstanceSpawned;
    private int currentCount = 0;

    private void Update()
    {
        if (forceSpawn)
        {
            instantiateObject();
            forceSpawn = false;
        }
    }

    public void instantiateObject()
    {
        
        if (objectInstance != null)
        {

            lastInstanceSpawned = Instantiate(objectInstance, transform.position, transform.rotation, transform);
            Debug.Log("count: " + currentCount + " childCount: " +transform.childCount);
            if (transform.childCount > maxNumber && !disableMaxCount)
            {
                deleteChildren();
            }
        }
        else
        {
            Debug.Log("ObjectInstance to spawn not assigned");
        }
    }

    public void deleteChildren()
    {
        //Debug.Log("current count: " + currentCount + " last obj " + lastInstanceSpawned.gameObject.name);
        foreach (Transform child in transform)
        {
            //Debug.Log("child: " + child.gameObject + " *** lastInstance: " + lastInstanceSpawned.gameObject);
            if (child.gameObject != lastInstanceSpawned.gameObject)
            {
                Destroy(child.gameObject);
            }
        }

    }
}

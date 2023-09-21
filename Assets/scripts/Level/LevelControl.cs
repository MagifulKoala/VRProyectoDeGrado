using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject xrOrigin;
    UnityEvent enableLeftHandPowers;


    private void Start()
    {
        xrOrigin.transform.position = spawnPoint.position;
        xrOrigin.transform.localEulerAngles = spawnPoint.localEulerAngles;
    }


    public void reloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }


    public void resetPlayer()
    {
        Debug.Log("player pos:" + xrOrigin.transform.position);
        Debug.Log("respawn pos:" + spawnPoint.transform.position);
        xrOrigin.transform.position = spawnPoint.transform.position;
        xrOrigin.transform.localEulerAngles = spawnPoint.transform.localEulerAngles;
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("worldBarrier"))
        {
            //resetPlayer();
            reloadLevel();
        }
    }



}

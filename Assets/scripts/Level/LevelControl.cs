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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("worldBarrier"))
        {
            reloadLevel();
        }    
    }



}

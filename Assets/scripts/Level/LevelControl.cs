using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class LevelControl : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject xrOrigin;
    [SerializeField] ContinuousMoveProviderBase continuousMoveProvider; 
    [SerializeField] bool resetXROrigin; 

    [SerializeField] bool useSpawnPoint = true;
    UnityEvent enableLeftHandPowers;


    private void Start()
    {
        UnityEngine.XR.XRSettings.gameViewRenderMode = UnityEngine.XR.GameViewRenderMode.RightEye;

        if(spawnPoint != null && useSpawnPoint)
        {
        xrOrigin.transform.position = spawnPoint.position;
        xrOrigin.transform.localEulerAngles = spawnPoint.localEulerAngles;
        }
    }


    public void reloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }

    public bool checkPlayerPosition(UnityEngine.Vector3 pPosition)
    {
        UnityEngine.Vector3 playerPos = xrOrigin.transform.position;
        if(playerPos == pPosition)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }


    public void resetPlayer()
    {
        continuousMoveProvider.useGravity = false;

        Debug.Log("player reset");
        xrOrigin.transform.position = spawnPoint.transform.position;
        xrOrigin.transform.localEulerAngles = spawnPoint.transform.localEulerAngles;

        continuousMoveProvider.useGravity = true;
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("worldBarrier"))
        {
            reloadLevel(); 
        }
    }





}

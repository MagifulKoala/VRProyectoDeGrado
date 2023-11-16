using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalControll : MonoBehaviour
{
    [SerializeField] int sceneID;
    [SerializeField] AudioClip idlePortalClip;
    [SerializeField] AudioClip traveresePortalClip; 

    AudioSource portalAudioSource;

    private void Start()
    {
        portalAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(!portalAudioSource.isPlaying)
        {
            playClip(idlePortalClip);
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            playClip(traveresePortalClip);
            SceneManager.LoadScene(sceneID);
        }    
    }

    private void playClip(AudioClip pAudioClip)
    {
        if(portalAudioSource != null)
        {
            portalAudioSource.PlayOneShot(pAudioClip); 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExplosiveMaterial : MonoBehaviour
{
    [SerializeField] GameObject explosiveParticleSystem;
    [SerializeField] public float explosivePower = 200f;
    [SerializeField] float finalExplosionSize = 3f;
    [SerializeField] float explosionExpansionRate = 1f;
    [SerializeField] float explosionTime = 5f;
    [SerializeField] bool explosionTriggered = false;
    public bool explosionInProgress = false;
    ObjectControll parentObjectControll;
    SphereCollider sphereCollider;
    Timer timer;
    TMP_Text explotionTextTime; 
    AudioSource explosionAudio; 
    bool timerIsOn = false;
    bool particleSystemTriggered = false;

    private void Start()
    {
        explotionTextTime = transform.GetChild(0).GetComponent<TMP_Text>();
        explosionAudio = GetComponent<AudioSource>();
        
        sphereCollider = GetComponent<SphereCollider>();
        timer = GetComponent<Timer>();
        if (transform.parent != null)
        {
            parentObjectControll = transform.parent.GetComponent<ObjectControll>();
            parentObjectControll.ExplosionTriggered.AddListener(generateExplosion);
        }
        if (timer != null)
        {
            timer.setTotalTime(explosionTime);
        }
    }


    private void Update()
    {
        if (explosionTriggered)
        {
            if (!timerIsOn)
            {
                timer.startTimer();
                timerIsOn = true;
                explotionTextTime.gameObject.SetActive(true);
            }

            explotionTextTime.text = timer.getTimeLeft().ToString("F2"); 

            if (timer.timerHasFinished)
            {
                //Debug.Log("BOOOM");
                explosionInProgress = true;
                sphereCollider.radius += explosionExpansionRate;
                if (!particleSystemTriggered)
                {
                    startParticleSystem(explosiveParticleSystem);
                    explosionAudio.Play(); 
                }

                if (sphereCollider.radius >= finalExplosionSize)
                {
                    //Debug.Log("final radius is:" + sphereCollider.radius);
                    explosionTriggered = false;
                    Destroy(transform.parent.gameObject, 0.7f);
                }

            }
        }

    }

    private void startParticleSystem(GameObject pParticleSystem)
    {
        Instantiate(pParticleSystem, transform.position, transform.rotation, transform);
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
        ps.Play();
        particleSystemTriggered = true;
    }

    private void generateExplosion() => explosionTriggered = true;




}

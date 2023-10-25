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
    bool explosionUnparented = false;

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

            if (!timer.timerHasFinished)
            {
                explotionTextTime.text = timer.getTimeLeft().ToString("F1");
            }

            if (timer.timerHasFinished)
            {

                //Debug.Log("BOOOM");
                explosionInProgress = true;
                explotionTextTime.text = "";
                if (!explosionUnparented)
                {
                    unParentExplosion();
                }
                //Debug.Log(sphereCollider + " current radius " + sphereCollider.radius);
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
                    Destroy(transform.gameObject, 1.963f);
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

    private void unParentExplosion()
    {
        GameObject oldParent = transform.parent.gameObject;
        gameObject.transform.parent = null;
        Destroy(oldParent);
        explosionUnparented = true;
    }

    private void generateExplosion() => explosionTriggered = true;




}

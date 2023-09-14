using System.Collections;
using System.Collections.Generic;
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
    bool timerIsOn = false;
    bool particleSystemTriggered = false;

    private void Start()
    {
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
            }

            if (timer.timerHasFinished)
            {
                //Debug.Log("BOOOM");
                explosionInProgress = true;
                sphereCollider.radius += explosionExpansionRate;
                if (!particleSystemTriggered)
                {
                    startParticleSystem(explosiveParticleSystem);
                }

                if (sphereCollider.radius >= finalExplosionSize)
                {
                    //Debug.Log("final radius is:" + sphereCollider.radius);
                    explosionTriggered = false;
                    Destroy(transform.parent.gameObject, 0.5f);
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

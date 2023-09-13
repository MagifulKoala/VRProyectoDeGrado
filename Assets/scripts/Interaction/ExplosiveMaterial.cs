using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveMaterial : MonoBehaviour
{
    [SerializeField] ParticleSystem explosiveParticleSystem;
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
            if(!timerIsOn)
            {
                timer.startTimer(); 
                timerIsOn = true; 
            }

            if (timer.timerHasFinished)
            {
                Debug.Log("BOOOM");
                explosionInProgress = true; 
                sphereCollider.radius += explosionExpansionRate;
                if (sphereCollider.radius >= finalExplosionSize)
                {
                    Debug.Log("final radius is:" + sphereCollider.radius);
                    explosionTriggered = false;
                    Destroy(transform.parent.gameObject, 0);
                }

            }
        }

    }

    private void generateExplosion() => explosionTriggered=true; 




}

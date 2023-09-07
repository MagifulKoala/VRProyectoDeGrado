using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObjectControll : SimpleObjectController
{

    [SerializeField] GameObject meltingParticleSystem;
    [SerializeField] GameObject onFireParticleSystem;
    [SerializeField] float fireDamage = 1f;

    [SerializeField] float lifePoints = 3f;
     [SerializeField] private float radiusOffset = 1f;

    public const string fireParticleTag = "fireParticle";



    public bool particleSystemOn = false; 

    public bool isOnfire = false;
    public bool isMelting = false;
   

    protected override void Start()
    {
        base.Start(); 
    }

    private void Update()
    {
        checkStatus();
    }

    public void checkStatus()
    {
        if (isOnfire)
        {
            if (onFireParticleSystem != null && !particleSystemOn)
            {
                startParticleSystem(onFireParticleSystem);
            }
            recieveDamage(fireDamage * Time.deltaTime);
        }
        else if (isMelting)
        {
            if (meltingParticleSystem != null! && !particleSystemOn)
            {
                startParticleSystem(meltingParticleSystem);
            }
            recieveDamage(fireDamage * Time.deltaTime);
        }
        //Debug.Log("isOnFire: " + isOnfire + "isMelting: " + isMelting);
    }

    private void startParticleSystem(GameObject pParticleSystem)
    {
        GameObject particleObject = Instantiate(pParticleSystem, transform.position, transform.rotation, transform);
        if(pParticleSystem == onFireParticleSystem)
        {
            particleObject.GetComponent<SphereCollider>().radius += radiusOffset; //adjust collider specific to the onFire
        }
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
        ps.Play();
        particleSystemOn = true;
    }




    public void applyMaterialProperties()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = materialCtrl.mass;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enteres ObjectControll + " + other.gameObject);
        if (other.gameObject.tag == fireParticleTag)
        {
            if (materialCtrl.isFlammable)
            {
                isOnfire = true;
            }
            else if (materialCtrl.canMelt)
            {
                isMelting = true;
            }
        }

    }


    private void recieveDamage(float damageAmount)
    {
        lifePoints -= damageAmount;
        if (lifePoints <= 0)
        {
            Destroy(gameObject, 1);
        }
    }
}

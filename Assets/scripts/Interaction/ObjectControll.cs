using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody))]
public class ObjectControll : SimpleObjectController
{

    [SerializeField] GameObject meltingParticleSystem;
    [SerializeField] GameObject onFireParticleSystem;
    [SerializeField] GameObject explosiveInstance;
    [SerializeField] float fireDamage = 1f;
    [SerializeField] float lifePoints = 3f;
    //[SerializeField] private float radiusOffset = 1f;
    public Rigidbody rb;

    public const string fireParticleTag = "fireParticle";
    public bool particleSystemOn = false;

    public bool isOnfire = false;
    public bool isMelting = false;

    public bool explosionInitiated = false;

    public UnityEvent ExplosionTriggered;


    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        if (material.name == "explosive")
        {
            changeMaterialSpecial(material);
        }
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
        if (pParticleSystem == onFireParticleSystem)
        {
            //particleObject.GetComponent<SphereCollider>().radius += radiusOffset; //adjust collider specific to the onFire
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
        //Debug.Log("trigger enters ObjectControll + " + other.gameObject);
        if (other.gameObject.tag == fireParticleTag)
        {
            if (materialCtrl.isFlammable)
            {
                isOnfire = true;
            }
            if (materialCtrl.canMelt)
            {
                isMelting = true;
            }
            if (materialCtrl.explosive)
            {
                Debug.Log("explosive recognized");
                explosionInitiated = true;
                ExplosionTriggered?.Invoke();
            }
        }
        if (other.gameObject.CompareTag("explosive"))
        {
            ExplosiveMaterial explosiveMaterial = other.gameObject.GetComponent<ExplosiveMaterial>();
            if (explosiveMaterial.explosionInProgress)
            {
                Debug.Log("explosionInProgress recognized");
                float explosionPower = explosiveMaterial.explosivePower;
                applyExplotion(explosionPower);
            }
        }


    }

    private void applyExplotion(float pExplosionMagnitud)
    {
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.drag = 0.2f;
        UnityEngine.Vector3 explosionForceVector = UnityEngine.Random.onUnitSphere;
        rb.AddForce(explosionForceVector * pExplosionMagnitud);

    }

    private void recieveDamage(float damageAmount)
    {
        lifePoints -= damageAmount;
        if (lifePoints <= 0)
        {
            Destroy(gameObject, 1);
        }
    }

    public void changeMaterialSpecial(GameObject pNewMaterial)
    {
        changeMaterial(pNewMaterial);
        if (material.name == "explosive")
        {
            Instantiate(explosiveInstance, transform.position, transform.rotation, transform);
        }
    }
}

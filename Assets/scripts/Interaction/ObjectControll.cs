using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody))]
public class ObjectControll : SimpleObjectController
{

    [SerializeField] GameObject meltingParticleSystem;
    [SerializeField] GameObject onFireParticleSystem;
    [SerializeField] GameObject explosiveInstance;
    [SerializeField] float fireDamage = 1f;
    [SerializeField] float lifePoints = 3f;
    //[SerializeField] private float radiusOffset = 1f;
    [SerializeField] private List<GameObject> collidingObjects = new List<GameObject>();
    public Rigidbody rb;

    public const string fireParticleTag = "fireParticle";
    public bool particleSystemOn = false;

    public bool isOnfire = false;
    public bool isMelting = false;

    public bool explosionInitiated = false;

    public UnityEvent ExplosionTriggered;
    public UnityEvent ObjectDestroyed;
    public UnityEvent objectOnFire;
    public UnityEvent objectMelting;


    public bool getIsOnFire => isOnfire;
    public bool getIsMelting => isMelting;


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
                objectOnFire?.Invoke();
            }
            recieveDamage(fireDamage * Time.deltaTime);
        }
        else if (isMelting)
        {
            if (meltingParticleSystem != null! && !particleSystemOn)
            {
                startParticleSystem(meltingParticleSystem);
                objectMelting?.Invoke();
            }
            recieveDamage(fireDamage * Time.deltaTime);
        }
        //Debug.Log("isOnFire: " + isOnfire + "isMelting: " + isMelting);
    }

    private void startParticleSystem(GameObject pParticleSystem)
    {
        UnityEngine.Vector3 objectSize = transform.GetComponent<Renderer>().bounds.size;
        UnityEngine.Vector3 spawnPoint = transform.position;

        spawnPoint.y += objectSize.y / 2;
        GameObject particleObject = Instantiate(pParticleSystem, spawnPoint, transform.rotation, transform);
        //GameObject particleObject = Instantiate(pParticleSystem, transform.position , transform.rotation, transform);
        particleObject.transform.localScale = transform.localScale;




        if (pParticleSystem == onFireParticleSystem)
        {
            //adjust flame radius
            particleObject.GetComponent<SphereCollider>().radius = particleObject.GetComponent<SphereCollider>().radius
            * (1 / (transform.localScale.magnitude / Mathf.Sqrt(3))) * 1.25f;

        }
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
        /*     //emmission shape 
            var sh = ps.shape;
            sh.shapeType = ParticleSystemShapeType.Mesh;
            sh.mesh = GetComponent<MeshFilter>().mesh; 
            // */
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
        Debug.Log(other.gameObject);
        collidingObjects.Add(other.gameObject);

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
                //Debug.Log("explosive recognized");
                explosionInitiated = true;
                ExplosionTriggered?.Invoke();
            }
        }
        if (other.gameObject.CompareTag("explosive"))
        {
            ExplosiveMaterial explosiveMaterial = other.gameObject.GetComponent<ExplosiveMaterial>();
            if (explosiveMaterial.explosionInProgress)
            {
                //Debug.Log("explosionInProgress recognized");
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
            if (isMelting)
            {
                putOutFires();
            }
            ObjectDestroyed?.Invoke();
            Destroy(gameObject, 1);
        }
    }

    private void putOutFires()
    {
        foreach (var obj in collidingObjects)
        {
            GameObject parent = obj.transform.parent.gameObject;
            ObjectControll parentObjControl = parent.GetComponent<ObjectControll>(); 
            if(parentObjControl != null)
            {
                if(parentObjControl.isOnfire)
                {
                    parentObjControl.isOnfire = false; 
                    parentObjControl.particleSystemOn = false; 
                }
            }
            Destroy(obj,1.001f); 

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

/*     private void OnCollisionEnter(Collision other)
    {
        collidingObjects.Add(other.gameObject);
    }

    private void OnCollisionExit(Collision other)
    {
        foreach (var obj in collidingObjects)
        {
            if (obj.gameObject == other.gameObject)
            {
                collidingObjects.Remove(obj);
            }
        }
    } */

    private void OnTriggerExit(Collider other)
    {
        GameObject objToRemove = null;
        foreach (var obj in collidingObjects)
        {
            if (obj == other.gameObject)
            {
                objToRemove = obj;
                break;
            }
        }
        if(objToRemove != null)
        {
            collidingObjects.Remove(objToRemove);
        }
    }


}

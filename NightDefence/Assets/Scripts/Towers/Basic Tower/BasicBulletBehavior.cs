using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletBehavior : MonoBehaviour
{
    public float givenDamage, bulletSpeed;
    private bool expired = false;
    Rigidbody rb;

    //basic
    public bool burningEffect;
    public float burnDamage;

    //sniper
    public bool bounceEffect, scatterEffect;
    public int bounceAmount = 1;
    private GameObject nextTarget;

    //shotgun
    RaycastHit hit;
    public LayerMask mask;
    public float scatterStartRange;

    private void Start()
    {
        Destroy(gameObject, 4);
        transform.GetComponent<Collider>().enabled = false;
        ColliderOn();
        Invoke("ColliderOn", 0.1f);
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.TransformDirection(0,0,bulletSpeed);
    }
    private void Update()
    {
        IsBouncable();
        Debugf();

        //transform.rotation = Quaternion.LookRotation(transform.TransformDirection(transform.forward));
    }
    private void OnCollisionEnter(Collision col)
    {
        if (expired == false)
        {
            if (col.gameObject.tag == "Enemy")
            {
                if (bounceEffect == true)
                {
                    bounceAmount--;
                    col.gameObject.GetComponent<HealthScript>().DoDamage(givenDamage, burnDamage);

                    nextTarget = FindObjectOfType<HealthScript>().gameObject;
                    transform.LookAt(nextTarget.transform, Vector3.up);
                    rb.velocity = transform.TransformDirection(transform.forward.x, transform.forward.y, bulletSpeed);
                }
                else
                {
                    expired = true;
                    Destroy(gameObject, 2);
                    if (burningEffect == true)
                    {
                        burnDamage = 50;
                    }
                    col.gameObject.GetComponent<HealthScript>().DoDamage(givenDamage, burnDamage);
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    gameObject.GetComponent<Light>().enabled = false;
                    rb.isKinematic = true;
                }
            }
        }
    }
    private void IsBouncable()
    {
        if (bounceAmount == 0)
        {
            bounceEffect = false;
        }
    }
    public void ColliderOn()
    {
        transform.GetComponent<Collider>().enabled = true;
    }

    public void Debugf()
    {
        Debug.DrawRay(transform.position, transform.forward * scatterStartRange, Color.red);
    }
}
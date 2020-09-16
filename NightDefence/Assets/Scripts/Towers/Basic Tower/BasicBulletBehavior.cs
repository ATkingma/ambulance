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
    public bool bounceEffect;
    public int bounceAmount = 1;
    private GameObject nextTarget;

    private void Start()
    {
        Destroy(gameObject, 4);
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        IsBouncable();
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
                    nextTarget = FindObjectOfType<HealthScript>().gameObject;
                    transform.LookAt(nextTarget.transform, Vector3.up);
                    rb.velocity = transform.TransformDirection(transform.forward.x, transform.forward.y, bulletSpeed);
                }
                else
                {
                    expired = true;
                    Destroy(gameObject, 2);
                    if(burningEffect == true)
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
        if(bounceAmount == 0)
        {
            bounceEffect = false;
        }
    }
}

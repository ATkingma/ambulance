using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletBehavior : MonoBehaviour
{
    public float givenDamage;
    private bool expired = false;
    Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, 4);
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (expired == false)
        {
            if (col.gameObject.tag == "Enemy")
            {
                expired = true;
                Destroy(gameObject, 2);
                col.gameObject.GetComponent<HealthScript>().DoDamage(givenDamage);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<Light>().enabled = false;
                rb.isKinematic = true;
            }
        }
    }
}

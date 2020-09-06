using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletBehavior : MonoBehaviour
{
    public float givenDamage;
    private bool expired = false;

    private void Start()
    {
        Destroy(gameObject, 10);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (expired == false)
        {
            if (col.gameObject.tag == "Enemy")
            {
                //col.gameObject.GetComponent<Health>().Health(givenDamage);
                Destroy(gameObject);
                expired = true;
            }
        }
    }
}

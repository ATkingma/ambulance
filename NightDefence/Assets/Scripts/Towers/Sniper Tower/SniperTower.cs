using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTower : MonoBehaviour
{
    public Rigidbody bullet;
    public float bulletSpeed;
    //public GameObject audioData;
    public float end_Damage;
    public void Fire()
    {
        Rigidbody clone;
        clone = Instantiate(bullet, transform.position, Quaternion.LookRotation(transform.forward));
        clone.gameObject.GetComponent<BasicBulletBehavior>().givenDamage = end_Damage;
        clone.velocity = transform.TransformDirection(transform.forward.x, transform.forward.y, bulletSpeed);

        //audioData.GetComponent<AudioSource>().Play();
    }

    public void RecieveDamage(float dmg)
    {
        end_Damage = dmg;
    }
}

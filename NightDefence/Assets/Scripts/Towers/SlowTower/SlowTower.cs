using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : MonoBehaviour
{
    public Rigidbody bullet;
    public float bulletSpeed;
    //public GameObject audioData;
    public float end_Damage;
    public bool slowLvl5;

    public void Fire()
    {
        Rigidbody clone;
        clone = Instantiate(bullet, transform.position, Quaternion.LookRotation(transform.forward));
        if (slowLvl5 == true)
        {
            clone.gameObject.GetComponent<BasicBulletBehavior>().bounceEffect = true;
        }
        clone.gameObject.GetComponent<BasicBulletBehavior>().givenDamage = end_Damage;
        clone.gameObject.GetComponent<BasicBulletBehavior>().bulletSpeed = bulletSpeed;
        clone.velocity = transform.TransformDirection(transform.forward.x, transform.forward.y, bulletSpeed);

        //audioData.GetComponent<AudioSource>().Play();
    }

    public void RecieveDamage(float dmg)
    {
        end_Damage = dmg;
    }
}

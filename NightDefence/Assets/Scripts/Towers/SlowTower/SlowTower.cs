﻿using System.Collections;
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
        clone = Instantiate(bullet, transform.position, Quaternion.LookRotation(transform.forward), transform);
        if (slowLvl5 == true)
        {
            clone.gameObject.GetComponent<BulletBehavior>().givenDamage = end_Damage;
        }
        clone.gameObject.GetComponent<BulletBehavior>().frozenEffect = true;
        clone.gameObject.GetComponent<BulletBehavior>().bulletSpeed = bulletSpeed;
        clone.velocity = transform.TransformDirection(transform.forward.x, transform.forward.y, bulletSpeed);

        //audioData.GetComponent<AudioSource>().Play();
    }

    public void RecieveDamage(float dmg)
    {
        end_Damage = dmg;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : MonoBehaviour
{
    public Rigidbody bullet;
    public float bulletSpeed;
    public GameObject audioData;
    public float end_Damage;
    public bool laserLvl5;

    public void Fire()
    {
        

        audioData.GetComponent<AudioSource>().Play();
    }

    public void RecieveDamage(float dmg)
    {
        end_Damage = dmg;
    }
}

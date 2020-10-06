using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : MonoBehaviour
{
    public Rigidbody bullet;
    public float bulletSpeed;
    public GameObject audioData, line;
    public float end_Damage;
    public bool laserLvl5;

    public void Fire()
    {
        line.SetActive(true);
        Invoke("EndFire",5);

        audioData.GetComponent<AudioSource>().Play();
    }
    public void EndFire()
    {
        line.SetActive(false);
    }

    public void RecieveDamage(float dmg)
    {
        end_Damage = dmg;
    }
}

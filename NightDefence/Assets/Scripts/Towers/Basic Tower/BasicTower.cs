using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : MonoBehaviour
{
    public Rigidbody bullet;
    public float bulletSpeed;
    public Transform left, right;
    public bool toggle;
    public GameObject audioData,leftParticle,rightParticle;
    public float end_Damage;
    public bool basicLvl5;
    public float burnDamagerecieve;

    public void Fire()
    {
        Rigidbody clone;
        if (toggle == true)
        {
            clone = Instantiate(bullet, left.position, Quaternion.LookRotation(transform.forward));
            if(basicLvl5 == true)
            {
                clone.gameObject.GetComponent<BulletBehavior>().burningEffect = true;
                rightParticle.SetActive(false);
                leftParticle.SetActive(true);
            }
            clone.gameObject.GetComponent<BulletBehavior>().givenDamage = end_Damage;
            clone.gameObject.GetComponent<BulletBehavior>().bulletSpeed = bulletSpeed;
            clone.velocity = transform.TransformDirection(transform.forward.x, transform.forward.y, bulletSpeed);
            Toggle();
        }
        else
        {
            clone = Instantiate(bullet, right.position, Quaternion.LookRotation(transform.forward));
            if (basicLvl5 == true)
            {
                clone.gameObject.GetComponent<BulletBehavior>().burningEffect = true;
                leftParticle.SetActive(false);
                rightParticle.SetActive(true);
            }
            clone.gameObject.GetComponent<BulletBehavior>().givenDamage = end_Damage;
            clone.gameObject.GetComponent<BulletBehavior>().bulletSpeed = bulletSpeed;
            clone.velocity = transform.TransformDirection(transform.forward.x, transform.forward.y, bulletSpeed);
            Toggle();
        }
        audioData.GetComponent<AudioSource>().Play();
    }

    public void RecieveDamage(float dmg)
    {
        end_Damage = dmg;
    }

    void Toggle()
    {
        toggle = !toggle;
    }
}

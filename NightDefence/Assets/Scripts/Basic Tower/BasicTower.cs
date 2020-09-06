using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : MonoBehaviour
{
    public Rigidbody bullet;
    public float bulletSpeed;
    public Transform left, right;
    public bool toggle;

    public float end_Damage;

    public void Fire()
    {
        Rigidbody clone;
        if (toggle == true)
        {
            clone = Instantiate(bullet, left.position, Quaternion.LookRotation(transform.forward));
            clone.gameObject.GetComponent<BasicBulletBehavior>().givenDamage = end_Damage;
            clone.velocity = transform.TransformDirection(transform.forward.x, transform.forward.y, bulletSpeed);
            Toggle();
        }
        else
        {
            clone = Instantiate(bullet, right.position, Quaternion.LookRotation(transform.forward));
            clone.gameObject.GetComponent<BasicBulletBehavior>().givenDamage = end_Damage;
            clone.velocity = transform.TransformDirection(transform.forward.x, transform.forward.y, bulletSpeed);
            Toggle();
        }
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

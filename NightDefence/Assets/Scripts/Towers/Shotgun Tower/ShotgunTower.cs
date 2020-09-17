using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunTower : MonoBehaviour
{
    public Rigidbody bullet;
    public float bulletSpeed;
    //public GameObject audioData;
    public float end_Damage;
    public bool shotgunLvl5;
    public int bulletAmount;
    public List<Transform> rotations;

    private void Start()
    {
        List<Transform> rotations = new List<Transform>(1000);
    }
    private void Update()
    {
        ShotgunLvl5();
    }
    public void Fire()
    {
        for(int i = 0; i < bulletAmount; i++)
        {
            Rigidbody clone;
            clone = Instantiate(bullet, rotations[i].position, Quaternion.LookRotation(rotations[i].forward));
            clone.gameObject.GetComponent<BasicBulletBehavior>().givenDamage = end_Damage;
            clone.gameObject.GetComponent<BasicBulletBehavior>().bulletSpeed = bulletSpeed;
            clone.velocity = transform.TransformDirection(rotations[i].forward.x, rotations[i].forward.y, rotations[i].forward.z);
        }
    }

    public void RecieveDamage(float dmg)
    {
        end_Damage = dmg;
    }
    public void ShotgunLvl5()
    {
        if (shotgunLvl5 == true)
        {
            bulletAmount = 5;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTargeting : MonoBehaviour
{
    public Transform shootOrigin;
    public float cooldown;
    public float attacksPerSec;
    private float nextFire;
    public LayerMask enemies;
    public List<Transform> targets;
    public List<float> upgradeValues;
    public bool rangeOn;
    public float upgradeCost, upgradeCount;
    public ParticleSystem.MainModule mainParticles;
    RaycastHit hit;
    public LineRenderer beam;
    public float damage;
    public Vector3 offsettBEAM;
    public bool laserLvl5;
    //public GameObject audioData;

    private void Start()
    {
        List<Transform> targets = new List<Transform>(1000);
        List<Transform> upgradeValues = new List<Transform>(1000);
        mainParticles = gameObject.transform.parent.GetComponentInChildren<ParticleSystem>().main;
        beam.SetPosition(0, shootOrigin.position);
        beam.SetPosition(1, shootOrigin.position);
    }
    private void Update()
    {
        targets.RemoveAll(GameObject => GameObject == null);

        //tower rotation
        if (targets.Count > 0)
        {
            beam.gameObject.SetActive(true);
            beam.SetPosition(0, shootOrigin.position + offsettBEAM);
            beam.SetPosition(1, targets[0].transform.position + offsettBEAM);
            if (Time.time > nextFire)
            {
                targets[0].GetComponent<HealthScript>().DoDamage(damage, default);
                //audioData.GetComponent<AudioSource>().Play();
                nextFire = Time.time + cooldown;
            }
        }
        else
        {
            beam.gameObject.SetActive(false);
        }
        RangeActive();
    }
    //check enemy inrange
    private void OnTriggerEnter(Collider enemyInRange)
    {
        if (enemyInRange.tag == "Enemy")
        {
            targets.Add(enemyInRange.transform);
        }
    }
    //check enemy out of range
    private void OnTriggerExit(Collider enemyOutOfRange)
    {
        if (enemyOutOfRange.tag == "Enemy")
        {
            targets.Remove(enemyOutOfRange.transform);
        }
    }

    public void RecieveAttackSpeed(float givenSpeed, float perSec)
    {
        cooldown = givenSpeed;
        attacksPerSec = perSec;
        UpgradeCost();
    }
    public void UpgradeCost()
    {
        upgradeCount++;
        upgradeCost = upgradeValues[(int)upgradeCount];
    }

    public void RangeActive()
    {
        if (rangeOn == false)
        {
            mainParticles.maxParticles = 0;
        }
        else
        {
            mainParticles.startLifetime = 2;
            mainParticles.maxParticles = 10000;
        }
        if (FindObjectOfType<UpgradeSelect>() == null)
        {
            rangeOn = false;
        }
    }
    public void RecieveDamage(float dmg)
    {
        damage = dmg;
    }
}

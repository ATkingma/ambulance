using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
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
    public LayerMask mask;
    private Transform targetPos;
    public float rotationDamping;
    //public GameObject audioData;

    private void Start()
    {
        List<Transform> targets = new List<Transform>(1000);
        List<Transform> upgradeValues = new List<Transform>(1000);
        mainParticles = gameObject.transform.parent.GetComponentInChildren<ParticleSystem>().main;
    }
    private void FixedUpdate()
    {
        targets.RemoveAll(GameObject => GameObject == null);
        if (targetPos != null && targets.Count > 0)
        {
            Vector3 lookPos = targetPos.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        }
        if (targets.Count > 0)
        {
            targetPos = targets[0].gameObject.transform;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10000, mask))
            {
                beam.gameObject.SetActive(true);
                beam.SetPosition(1, new Vector3(0,0,1) * hit.distance);
                if (Time.time > nextFire)
                {
                    hit.transform.GetComponent<HealthScript>().DoDamage(damage, default);
                    //audioData.GetComponent<AudioSource>().Play();
                    nextFire = Time.time + cooldown;
                }
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

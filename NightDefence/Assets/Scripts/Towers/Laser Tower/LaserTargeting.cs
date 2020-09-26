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
    public Rigidbody BEAM;
    public LayerMask mask;
    private bool toggle;
    public Material lightning1, lightning2;
    //public GameObject audioData;

    private void Start()
    {
        List<Transform> targets = new List<Transform>(1000);
        List<Transform> upgradeValues = new List<Transform>(1000);
        mainParticles = gameObject.transform.parent.GetComponentInChildren<ParticleSystem>().main;
        beam.SetPosition(0, shootOrigin.position);
        beam.SetPosition(1, shootOrigin.position);
    }
    private void FixedUpdate()
    {
        targets.RemoveAll(GameObject => GameObject == null);

        //tower 
        if(laserLvl5 == true)
        {
            if (Time.time > nextFire)
            {
                beam.gameObject.SetActive(false);
                foreach (Transform tar in targets)
                {
                    Rigidbody clone;
                    clone = Instantiate(BEAM, transform.position, Quaternion.identity, transform);
                    clone.gameObject.SetActive(true);
                    clone.gameObject.GetComponent<LineRenderer>().startWidth = 1;
                    if(toggle == true)
                    {
                        clone.gameObject.GetComponent<LineRenderer>().material = lightning1;
                        toggle = !toggle;
                    }
                    else
                    {
                        clone.gameObject.GetComponent<LineRenderer>().material = lightning2;
                        toggle = !toggle;
                    }
                    clone.gameObject.GetComponent<LineRenderer>().SetPosition(0, shootOrigin.position + offsettBEAM);
                    clone.gameObject.GetComponent<LineRenderer>().SetPosition(1, tar.position + offsettBEAM);
                    tar.GetComponent<HealthScript>().DoDamage(damage, default);
                    Destroy(clone.gameObject, 0.05f);
                }
                nextFire = Time.time + cooldown;
            }
        }
        else
        {
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

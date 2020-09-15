﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    public Transform shootOrigin;
    private Transform targetPos;

    public float rotationDamping;
    public float cooldown;
    public float attacksPerSec;
    private float nextFire;
    public LayerMask enemies;
    public List<Transform> targets;
    public List<float> upgradeValues;
    public bool rangeOn, invokeStarted;
    public float upgradeCost, upgradeCount;
    public ParticleSystem.MainModule mainParticles;
    RaycastHit hit;
    private bool hitEnemy;

    private void Start()
    {
        List<Transform> targets = new List<Transform>(1000);
        List<Transform> upgradeValues = new List<Transform>(1000);
        mainParticles = gameObject.transform.parent.GetComponentInChildren<ParticleSystem>().main;
    }
    private void Update()
    {
        //tower rotation
        if(targetPos != null && targets.Count > 0)
        {
            Vector3 lookPos = targetPos.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        }
        //raycast
        if (Physics.Raycast(transform.position + transform.up * 0.85f, transform.forward, out hit, GetComponent<CapsuleCollider>().radius * 0.3f, enemies))
        {
            if (hit.transform.tag == "Enemy")
            { 
                if (Time.time > nextFire)
                {
                    if (gameObject.transform.parent.tag == "BasicTower")
                    {
                        shootOrigin.GetComponent<BasicTower>().Fire();
                    }
                    if (gameObject.transform.parent.tag == "SniperTower")
                    {
                        shootOrigin.GetComponent<SniperTower>().Fire();

                        if (invokeStarted == false)
                        {
                            invokeStarted = true;
                            SniperTowerMatChangeoff();
                        }
                    }
                    nextFire = Time.time + cooldown;
                }
            }
        }
        Targeting();
        RangeActive();
        //raycast vision
        Debugf();
    }
    //check enemy inrange
    private void OnTriggerEnter(Collider enemyInRange)
    {
        if(enemyInRange.tag == "Enemy")
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

    public void Targeting()
    {
        targets.RemoveAll(GameObject => GameObject == null);
        if (targets.Count > 0)
        {
            targetPos = targets[0].gameObject.transform;
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

    public void Debugf()
    {
        Debug.DrawRay(transform.position + transform.up * 0.85f,transform.forward * (GetComponent<CapsuleCollider>().radius * 0.3f), Color.red, 0.5f);
    }
    public void SniperTowerMatChangeoff()
    {
        gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<MaterialHolder>().sniper0;
        Invoke("SniperTowerMatChange1", 1.0f);
    }
    public void SniperTowerMatChange1()
    {
        gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<MaterialHolder>().sniper1;
        Invoke("SniperTowerMatChange2", 1.0f);
    }
    public void SniperTowerMatChange2()
    {
        gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<MaterialHolder>().sniper2;
        Invoke("SniperTowerMatChange3", 1.0f);
    }
    public void SniperTowerMatChange3()
    {
        gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<MaterialHolder>().sniper3;
        Invoke("SniperTowerMatChange4", 1.0f);
    }
    public void SniperTowerMatChange4()
    {
        gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<MaterialHolder>().sniper4;
        Invoke("SniperTowerMatChange5", 1.0f);
    }
    public void SniperTowerMatChange5()
    {
        gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<MaterialHolder>().sniper5;
        invokeStarted = false;
    }
}

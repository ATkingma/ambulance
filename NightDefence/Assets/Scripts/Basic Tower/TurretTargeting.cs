using System.Collections;
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

    RaycastHit hit;

    private void Start()
    {
        List<Transform> targets = new List<Transform>(1000);
    }
    private void Update()
    {
        //tower rotation
        if(targetPos != null && targets.Count > 0)
        {
            Vector3 lookPos = targetPos.position - transform.position;
            lookPos.y -= 0.5f;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        }
        //raycast
        if (Physics.Raycast(transform.position + transform.up * 0.85f, transform.forward, out hit, GetComponent<CapsuleCollider>().radius * 0.3f, enemies))
        {
            if (hit.transform.tag == "Enemy")
            {
                if(Time.time > nextFire)
                {
                    shootOrigin.GetComponent<BasicTower>().Fire();
                    nextFire = Time.time + cooldown;
                }
            }
        }
        //raycast vision
        Debugf();
    }
    //check enemy inrange
    private void OnTriggerEnter(Collider enemyInRange)
    {
        if(enemyInRange.tag == "Enemy")
        {
            targets.Add(enemyInRange.transform);

            Targeting();
        }
    }
    //check enemy out of range
    private void OnTriggerExit(Collider enemyOutOfRange)
    {
        if (enemyOutOfRange.tag == "Enemy")
        {
            targets.Remove(enemyOutOfRange.transform);
            Targeting();
        }
    }

    public void Targeting()
    {
        if (targets.Count > 0)
        {
            targetPos = targets[0].gameObject.transform;
        }
        else
        {
            return;
        }
    }

    public void RecieveAttackSpeed(float givenSpeed, float perSec)
    {
        cooldown = givenSpeed;
        attacksPerSec = perSec;
    }

    public void Debugf()
    {
        Debug.DrawRay(transform.position + transform.up * 0.85f,transform.forward * (GetComponent<CapsuleCollider>().radius * 0.3f), Color.red, 0.5f);
    }
}

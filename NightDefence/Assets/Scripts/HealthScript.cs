using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health;
    public float centjes;
    private GameObject gameManager;

    public float burnDamage, burning;
    public bool isBurning;

    private void Start()
    {
        gameManager = FindObjectOfType<Centjes>().gameObject;
    }
    public void DoDamage(float oof, float overTimeDamage)
    {
        health -= oof;

        if(overTimeDamage > 0)
        {
            isBurning = true;
            burnDamage = overTimeDamage;
            burning = Time.time + 5;
            print(burning);
            print(Time.time);
        }
    }

    private void Update()
    {
        if (isBurning == true)
        {
            health -= burnDamage * Time.deltaTime;
            if(Time.time > burning)
            {
                isBurning = false;
            }
        }
        if (health <= 0)
        {
            //ragdol ding
            gameManager.GetComponent<Centjes>().CentjesErBij(centjes);
        }
    }
}
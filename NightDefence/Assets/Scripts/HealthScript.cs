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
    public GameObject flames;

    private void Start()
    {
        gameManager = FindObjectOfType<Centjes>().gameObject;
    }
    public void DoDamage(float oof, float overTimeDamage, float isSlowed)
    {
        health -= oof;

        if(overTimeDamage > 0)
        {
            flames.SetActive(true);
            isBurning = true;
            burnDamage = overTimeDamage;
            burning = Time.time + 5;
        }
        else
        {
            flames.SetActive(false);
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
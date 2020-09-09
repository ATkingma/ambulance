using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health;
    public float centjes;
    private GameObject gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<Centjes>().gameObject;
    }
    public void DoDamage(float oof)
    {
        print("OOF");
        health -= oof;

        //dood
        if(health <= 0)
        {
            //ragdol ding
            gameManager.GetComponent<Centjes>().CentjesErBij(centjes);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health;
    
    public void DoDamage(float oof)
    {
        print("OOF");
        health -= oof;
    }
}

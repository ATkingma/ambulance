using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculation : MonoBehaviour
{
    [Header("BasicTower stats")]
    public float baseDamage_Basic;
    public float upgradeDamage;
    public float baseSpeed_Basic;
    public float upgradeSpeed;

    public GameObject tower, barrel;
    private float end_Damage, end_Speed, attackPerSec;

    private void Start()
    {
        AttackDamage_Basic(default);
        AttackSpeed_Basic(default);
    }
    public void AttackDamage_Basic(float upgradePoints)
    {
        end_Damage = baseDamage_Basic + (upgradeDamage * upgradePoints);
        barrel.GetComponent<BasicTower>().RecieveDamage(end_Damage);
    }
    public void AttackSpeed_Basic(float upgradePoints)
    {
        end_Speed = baseSpeed_Basic - (upgradeSpeed * upgradePoints);
        if (upgradePoints > 0)
        {
            attackPerSec = baseSpeed_Basic - (upgradeSpeed / upgradePoints);
        }
        else
        {
            attackPerSec = 1;
        }
        tower.GetComponent<TurretTargeting>().RecieveAttackSpeed(end_Speed, attackPerSec);
    }
}

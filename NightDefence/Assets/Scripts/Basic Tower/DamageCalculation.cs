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

    private float upgradePoint_Damage = -1, upgradePoint_Speed = -1;

    private void Start()
    {
        AttackDamage_Basic();
        AttackSpeed_Basic();
    }
    public void AttackDamage_Basic()
    {
        upgradePoint_Damage++;
        end_Damage = baseDamage_Basic + (upgradeDamage * upgradePoint_Damage);
        barrel.GetComponent<BasicTower>().RecieveDamage(end_Damage);
    }
    public void AttackSpeed_Basic()
    {
        upgradePoint_Speed++;
        end_Speed = baseSpeed_Basic - (upgradeSpeed * upgradePoint_Speed);
        if (upgradePoint_Speed > 0)
        {
            attackPerSec = 1 / (baseSpeed_Basic - upgradeSpeed * upgradePoint_Speed);
        }
        else
        {
            attackPerSec = 1;
        }
        tower.GetComponent<TurretTargeting>().RecieveAttackSpeed(end_Speed, attackPerSec);
    }
}

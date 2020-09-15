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
    public float end_Damage, end_Speed, attackPerSec;

    public float upgradePoint;

    public void UpgradesRecieved(int towerNumber)
    {
        if(towerNumber == 10)
        {
            Attack_Basic();
        }
        if (towerNumber == 11)
        {
            Attack_Sniper();
        }
        // moet nog toe gevoegd worden
        //if (towerNumber == 12)
        //{
        //    AttackDamage_Slow();
        //    AttackSpeed_Slow();
        //}
        //if (towerNumber == 13)
        //{
        //    AttackDamage_Shotgun();
        //    AttackSpeed_Shotgun();
        //}
        //if (towerNumber == 14)
        //{
        //    AttackDamage_Laser();
        //    AttackSpeed_Laser();
        //}
    }
    #region basic
    public void Attack_Basic()
    {
        upgradePoint++;
        end_Damage = baseDamage_Basic + (upgradeDamage * upgradePoint);
        barrel.GetComponent<BasicTower>().RecieveDamage(end_Damage);

        end_Speed = baseSpeed_Basic - (upgradeSpeed * upgradePoint);
        if (upgradePoint > 0)
        {
            attackPerSec = 1 / (baseSpeed_Basic - upgradeSpeed * upgradePoint);
        }
        else
        {
            attackPerSec = 1;
        }
        tower.GetComponent<TurretTargeting>().RecieveAttackSpeed(end_Speed, attackPerSec);
    }
    #endregion
    #region sniper
    public void Attack_Sniper()
    {
        upgradePoint++;
        end_Damage = baseDamage_Basic + (upgradeDamage * upgradePoint);
        barrel.GetComponent<SniperTower>().RecieveDamage(end_Damage);

        end_Speed = baseSpeed_Basic - (upgradeSpeed * upgradePoint);
        if (upgradePoint > 0)
        {
            attackPerSec = 1 / (baseSpeed_Basic - upgradeSpeed * upgradePoint);
        }
        else
        {
            attackPerSec = 1;
        }
        tower.GetComponent<TurretTargeting>().RecieveAttackSpeed(end_Speed, attackPerSec);
    }
    #endregion
}

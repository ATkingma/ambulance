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

    private float upgradePoint_Damage = -1, upgradePoint_Speed = -1;

    private void Start()
    {
        //if(gameObject.transform.parent.tag == "BasicTower")
        //{
        //    AttackDamage_Basic();
        //    AttackSpeed_Basic();
        //}
        //if(gameObject.transform.parent.tag == "SniperTower")
        //{
        //    AttackDamage_Sniper();
        //    AttackSpeed_Sniper();
        //}
    }
    public void UpgradesRecieved(int towerNumber)
    {
        if(towerNumber == 10)
        {
            AttackDamage_Basic();
            AttackSpeed_Basic();
        }
        if (towerNumber == 11)
        {
            AttackDamage_Sniper();
            AttackSpeed_Sniper();
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
    #endregion
    #region sniper
    public void AttackDamage_Sniper()
    {
        upgradePoint_Damage++;
        end_Damage = baseDamage_Basic + (upgradeDamage * upgradePoint_Damage);
        barrel.GetComponent<SniperTower>().RecieveDamage(end_Damage);
    }
    public void AttackSpeed_Sniper()
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
    #endregion
}

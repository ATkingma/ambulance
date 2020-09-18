using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculation : MonoBehaviour
{
    [Header("BasicTower stats")]
    public float baseDamage;
    public float upgradeDamage;
    public float baseSpeed;
    public float upgradeSpeed;

    public GameObject tower, barrel;
    public float end_Damage, end_Speed, attackPerSec = 1;

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
        if (towerNumber == 13)
        {
            Attack_Shotgun();
        }
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
        end_Damage = baseDamage + (upgradeDamage * upgradePoint);
        barrel.GetComponent<BasicTower>().RecieveDamage(end_Damage);

        float fl = 0;
        end_Speed = baseSpeed + (upgradeSpeed * upgradePoint);
        attackPerSec = end_Speed;
        fl = end_Speed / (end_Speed * end_Speed);

        tower.GetComponent<TurretTargeting>().RecieveAttackSpeed(fl, attackPerSec);
        if (upgradePoint == 5)
        {
            barrel.GetComponent<BasicTower>().basicLvl5 = true;
        }
    }
    #endregion
    #region sniper
    public void Attack_Sniper()
    {
        upgradePoint++;
        end_Damage = baseDamage + (upgradeDamage * upgradePoint);
        barrel.GetComponent<SniperTower>().RecieveDamage(end_Damage);

        end_Speed = 1;
        attackPerSec = 0.2f;
        tower.GetComponent<TurretTargeting>().RecieveAttackSpeed(end_Speed, attackPerSec);
        if(upgradePoint == 5)
        {
            barrel.GetComponent<SniperTower>().sniperLvl5 = true;
        }
    }
    #endregion
    #region slow
    #endregion
    #region shotgun
    public void Attack_Shotgun()
    {
        upgradePoint++;
        end_Damage = baseDamage + (upgradeDamage * upgradePoint);
        barrel.GetComponent<ShotgunTower>().RecieveDamage(end_Damage);

        float fl = 0;
        end_Speed = baseSpeed + (upgradeSpeed * upgradePoint);
        attackPerSec = end_Speed;
        fl = end_Speed / (end_Speed * end_Speed);

        tower.GetComponent<TurretTargeting>().RecieveAttackSpeed(fl, attackPerSec);
        if (upgradePoint == 5)
        {
            barrel.GetComponent<ShotgunTower>().shotgunLvl5 = true;
        }
    }
    #endregion
}

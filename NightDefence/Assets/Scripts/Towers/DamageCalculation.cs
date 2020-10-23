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
        if (towerNumber == 12)
        {
            Attack_Slow();
        }
        if (towerNumber == 13)
        {
            Attack_Shotgun();
        }
        if (towerNumber == 14)
        {
            Attack_Laser();
        }
        if (towerNumber == 15)
        {
            Attack_Beam();
        }
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
    public void Attack_Slow()
    {
        upgradePoint++;
        end_Damage = baseDamage + (upgradeDamage * upgradePoint);
        barrel.GetComponent<SlowTower>().RecieveDamage(end_Damage);

        end_Speed = 0.1f;
        attackPerSec = 10f;
        tower.GetComponent<TurretTargeting>().RecieveAttackSpeed(end_Speed, attackPerSec);
        if (upgradePoint == 5)
        {
            barrel.GetComponent<SlowTower>().slowLvl5 = true;
        }
    }
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
    #region laser
    public void Attack_Laser()
    {
        upgradePoint++;
        end_Damage = baseDamage + (upgradeDamage * upgradePoint);
        tower.GetComponent<LaserTargeting>().RecieveDamage(end_Damage);

        end_Speed = 0.1f;
        attackPerSec = 10;
        tower.GetComponent<LaserTargeting>().RecieveAttackSpeed(end_Speed, attackPerSec);
        if (upgradePoint == 5)
        {
            tower.GetComponent<LaserTargeting>().laserLvl5 = true;
        }
    }
    #endregion
    #region BEAM
    public void Attack_Beam()
    {
        upgradePoint++;
        end_Damage = baseDamage + (upgradeDamage * upgradePoint);
        if (upgradePoint == 5)
        {
            tower.GetComponent<LaserBeam>().laserLvl5 = true;
        }
        tower.GetComponent<LaserBeam>().RecieveDamage(end_Damage);
        end_Speed = 0.1f;
        attackPerSec = 10;
        tower.GetComponent<LaserBeam>().RecieveAttackSpeed(end_Speed, attackPerSec);
    }
    #endregion
}

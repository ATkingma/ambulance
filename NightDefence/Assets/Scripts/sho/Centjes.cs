using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centjes : MonoBehaviour
{
    public float startCentjes;
    public float centjes;

    private void Start()
    {
        CentjesErBij(startCentjes);
    }

    public void CentjesErBij(float plus)
    {
        centjes += plus;
    }
    public void CentjesErAf(float min, int shopNumber)
    {
        float dummy = centjes;
        dummy -= min;
        if(dummy >= 0)
        {
            centjes -= min;
            if(shopNumber == 0)
            {
                FindObjectOfType<TowerSelect>().BasicTowerReturn();
            }
            if (shopNumber == 1)
            {
                FindObjectOfType<TowerSelect>().SniperTowerReturn();
            }
            if (shopNumber == 2)
            {
                FindObjectOfType<TowerSelect>().SlowTowerReturn();
            }
            if (shopNumber == 3)
            {
                FindObjectOfType<TowerSelect>().ShotgunTowerReturn();
            }
            if (shopNumber == 4)
            {
                FindObjectOfType<TowerSelect>().LaserTowerReturn();
            }
            //upgrades
            if(shopNumber == 10)
            {
                FindObjectOfType<UpgradeSelect>().BasicTower_DamageReturn();
            }
            if (shopNumber == 11)
            {

            }
            if (shopNumber == 12)
            {

            }
            if (shopNumber == 13)
            {

            }
            if (shopNumber == 14)
            {

            }
        }
        else
        {
            FindObjectOfType<CubePlacer>().CloseShop();
        }
    }
}

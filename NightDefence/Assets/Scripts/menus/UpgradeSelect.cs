using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeSelect : MonoBehaviour
{
    private TowerPlacer select;

    public List<TextMeshProUGUI> stats;
    public TextMeshProUGUI towerCost;
    public GameObject selectedTower, parent;
    public Button upgradeButton;
    private int towerSelect;

    //tutorial
    private bool nextLine = true;

    private void Start()
    {
        select = FindObjectOfType<TowerPlacer>();
        parent = selectedTower.transform.parent.gameObject;
    }
    public void SelectedTowerInfo(GameObject tower)
    {
        selectedTower = tower;
        parent = selectedTower.transform.parent.gameObject;
        UpgradeSelection();
    }

    public void UpgradeSelection()
    {
        //selecting wich tower it needs to upgrade
        //basic
        if (parent.tag == "BasicTower")
        {
            towerSelect = 10;
            stats[0].text = selectedTower.GetComponentInChildren<BasicTower>().end_Damage.ToString() + " Damage";
            stats[1].text = selectedTower.GetComponent<TurretTargeting>().attacksPerSec.ToString() + " /sec";
            stats[2].text = "Upgrades : " + selectedTower.GetComponent<TurretTargeting>().upgradeCount.ToString();
            if (selectedTower.GetComponent<TurretTargeting>().upgradeCount < 5)
            {
                towerCost.text = "(" + selectedTower.GetComponent<TurretTargeting>().upgradeCost.ToString() + ")";
            }
            else
            {
                towerCost.text = "(MAX)";
            }
        }
        //sniper
        if (parent.tag == "SniperTower")
        {
            towerSelect = 11;
            stats[0].text = selectedTower.GetComponentInChildren<SniperTower>().end_Damage.ToString() + " Damage";
            stats[1].text = selectedTower.GetComponent<TurretTargeting>().attacksPerSec.ToString() + " /sec";
            stats[2].text = "Upgrades : " + selectedTower.GetComponent<TurretTargeting>().upgradeCount.ToString();
            if (selectedTower.GetComponent<TurretTargeting>().upgradeCount < 5)
            {
                towerCost.text = "(" + selectedTower.GetComponent<TurretTargeting>().upgradeCost.ToString() + ")";
            }
            else
            {
                towerCost.text = "(MAX)";
            }
        }
        //slow
        if (selectedTower.transform.parent.tag == "SlowTower")
        {
            towerSelect = 12;
            stats[0].text = selectedTower.GetComponentInChildren<SlowTower>().end_Damage.ToString() + " Damage";
            stats[1].text = selectedTower.GetComponent<TurretTargeting>().attacksPerSec.ToString() + " /sec";
            stats[2].text = "Upgrades : " + selectedTower.GetComponent<TurretTargeting>().upgradeCount.ToString();
            if (selectedTower.GetComponent<TurretTargeting>().upgradeCount < 5)
            {
                towerCost.text = "(" + selectedTower.GetComponent<TurretTargeting>().upgradeCost.ToString() + ")";
            }
            else
            {
                towerCost.text = "(MAX)";
            }
        }
        //shotgun
        if (selectedTower.transform.parent.tag == "ShotgunTower")
        {
            towerSelect = 13;
            stats[0].text = selectedTower.GetComponentInChildren<ShotgunTower>().end_Damage.ToString() + " Damage";
            stats[1].text = selectedTower.GetComponent<TurretTargeting>().attacksPerSec.ToString() + " /sec";
            stats[2].text = "Upgrades : " + selectedTower.GetComponent<TurretTargeting>().upgradeCount.ToString();
            if(selectedTower.GetComponent<TurretTargeting>().upgradeCount < 5)
            {
                towerCost.text = "(" + selectedTower.GetComponent<TurretTargeting>().upgradeCost.ToString() + ")";
            }
            else
            {
                towerCost.text = "(MAX)";
            }
            
        }
        //laser
        if (selectedTower.transform.parent.tag == "LaserTower")
        {
            towerSelect = 14;
            stats[0].text = selectedTower.GetComponentInChildren<LaserTargeting>().damage.ToString() + " Damage";
            stats[1].text = selectedTower.GetComponent<LaserTargeting>().attacksPerSec.ToString() + " /sec";
            stats[2].text = "Upgrades : " + selectedTower.GetComponent<LaserTargeting>().upgradeCount.ToString();
            if (selectedTower.GetComponent<LaserTargeting>().upgradeCount < 5)
            {
                towerCost.text = "(" + selectedTower.GetComponent<LaserTargeting>().upgradeCost.ToString() + ")";
            }
            else
            {
                towerCost.text = "(MAX)";
            }
        }
        if (selectedTower.transform.parent.tag == "BeamTower")
        {
            towerSelect = 15;
            stats[0].text = selectedTower.GetComponentInChildren<LaserBeam>().damage.ToString() + " Damage";
            stats[1].text = selectedTower.GetComponent<LaserBeam>().attacksPerSec.ToString() + " /sec";
            stats[2].text = "Upgrades : " + selectedTower.GetComponent<LaserBeam>().upgradeCount.ToString();
            if (selectedTower.GetComponent<LaserBeam>().upgradeCount < 5)
            {
                towerCost.text = "(" + selectedTower.GetComponent<LaserBeam>().upgradeCost.ToString() + ")";
            }
            else
            {
                towerCost.text = "(MAX)";
            }
        }
    }
    //checking if you have enough centjes
    public void Tower()
    {
        if(nextLine)
        {
            nextLine = false;
            FindObjectOfType<Tutorial>().NextLine();
        }
        if(selectedTower.transform.parent.GetComponentInChildren<DamageCalculation>().upgradePoint < 5)
        {
            if (selectedTower.transform.parent.tag == "LaserTower")
            {
                FindObjectOfType<Centjes>().CentjesErAf(selectedTower.GetComponent<LaserTargeting>().upgradeCost, towerSelect);
            }
            else
            {
                if (selectedTower.transform.parent.tag == "BeamTower")
                {
                    FindObjectOfType<Centjes>().CentjesErAf(selectedTower.GetComponent<LaserBeam>().upgradeCost, towerSelect);
                }
                else
                {
                    FindObjectOfType<Centjes>().CentjesErAf(selectedTower.GetComponent<TurretTargeting>().upgradeCost, towerSelect);
                }
            }
        }
    }

    //upgrade the tower
    public void Return()
    {
        selectedTower.transform.parent.GetComponentInChildren<DamageCalculation>().UpgradesRecieved(towerSelect);
        CloseShop();
    }

    public void SellTower()
    {
        FindObjectOfType<UIScript>().SellMenuOn();
    }
    public void SellIsTrue()
    {
        if (selectedTower.transform.parent.tag == "LaserTower")
        {
            FindObjectOfType<Centjes>().CentjesErBij(selectedTower.GetComponent<LaserTargeting>().upgradeCost * 0.5f);
        }
        else
        {
            if (selectedTower.transform.parent.tag == "BeamTower")
            {
                FindObjectOfType<Centjes>().CentjesErBij(selectedTower.GetComponent<LaserBeam>().upgradeCost * 0.5f);
            }
            else
            {
                FindObjectOfType<Centjes>().CentjesErBij(selectedTower.GetComponent<TurretTargeting>().upgradeCost * 0.5f);
            }
        }
        FindObjectOfType<UIScript>().InGameUIOn();
        Destroy(parent);
        select.RemoveTower();
    }
    public void SellIsFalse()
    {
        FindObjectOfType<UIScript>().SellMenuOff();
    }

    //close the shop
    public void CloseShop()
    {
        select.CloseShop();
    }
}
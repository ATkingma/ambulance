using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeSelect : MonoBehaviour
{
    private CubePlacer select;

    public List<TextMeshProUGUI> stats;
    public GameObject selectedTower, parent;
    public Button upgradeButton;
    private int towerSelect;

    private void Start()
    {
        select = FindObjectOfType<CubePlacer>();
        List<Transform> towers = new List<Transform>();
        parent = selectedTower.transform.parent.gameObject;
    }
    public void SelectedTowerInfo(GameObject tower)
    {
        selectedTower = tower;
        parent = selectedTower.transform.parent.gameObject;
        stats[1].text = selectedTower.GetComponent<TurretTargeting>().attacksPerSec.ToString("F1") + " /sec";
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
        }
        //sniper
        if (parent.tag == "SniperTower")
        {
            towerSelect = 11;
            stats[0].text = selectedTower.GetComponentInChildren<SniperTower>().end_Damage.ToString() + " Damage";
        }
        //slow
        if (selectedTower.transform.parent.tag == "SlowTower")
        {
            towerSelect = 12;
            stats[0].text = selectedTower.GetComponentInChildren<SlowTower>().end_Damage.ToString() + " Damage";
        }
        //shotgun
        if (selectedTower.transform.parent.tag == "ShotgunTower")
        {
            towerSelect = 13;
            stats[0].text = selectedTower.GetComponentInChildren<ShotgunTower>().end_Damage.ToString() + " Damage";
        }
        //laser
        if (selectedTower.transform.parent.tag == "LaserTower")
        {
            towerSelect = 14;
        }
    }
    //checking if you have enough centjes
    public void Tower()
    {
        if(selectedTower.transform.parent.GetComponentInChildren<DamageCalculation>().upgradePoint < 5)
        {
            FindObjectOfType<Centjes>().CentjesErAf(selectedTower.GetComponent<TurretTargeting>().upgradeCost, towerSelect);
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
        FindObjectOfType<Centjes>().CentjesErBij(selectedTower.GetComponent<TurretTargeting>().upgradeCost * 0.5f);
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
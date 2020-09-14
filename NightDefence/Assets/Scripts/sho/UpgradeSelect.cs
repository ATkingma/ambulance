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
        stats[1].text = tower.transform.parent.GetComponentInChildren<DamageCalculation>().attackPerSec.ToString() + " /sec";
        stats[0].text = tower.transform.parent.GetComponentInChildren<DamageCalculation>().end_Damage.ToString() + " Damage";
        UpgradeSelection();
    }

    public void UpgradeSelection()
    {
        //selecting wich tower it needs to upgrade
        //basic
        if (parent.tag == "BasicTower")
        {
            towerSelect = 10;
        }
        //sniper
        if (parent.tag == "SniperTower")
        {
            towerSelect = 11;
        }
        //slow
        if (selectedTower.transform.parent.tag == "SlowTower")
        {
            towerSelect = 12;
        }
        //shotgun
        if (selectedTower.transform.parent.tag == "ShotgunTower")
        {
            towerSelect = 13;
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
        //print("basic");
        FindObjectOfType<Centjes>().CentjesErAf(selectedTower.GetComponent<TurretTargeting>().upgradeCost, towerSelect);
    }

    //upgrade the tower
    public void Return()
    {
        selectedTower.transform.parent.GetComponentInChildren<DamageCalculation>().UpgradesRecieved(towerSelect);

        CloseShop();
    }

    //close the shop
    public void CloseShop()
    {
        select.CloseShop();
    }
}
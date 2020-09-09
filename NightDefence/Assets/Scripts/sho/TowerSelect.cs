using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelect : MonoBehaviour
{
    private CubePlacer select;
    private Centjes bank;

    public List<float> towerCost;
    public List<Transform> towers;

    private void Start()
    {
        select = FindObjectOfType<CubePlacer>();
        bank = FindObjectOfType<Centjes>();
        List<Transform> towers = new List<Transform>();
        List<float> towerCost = new List<float>();
    }
    //basic
    public void BasicTower()
    {
        bank.CentjesErAf(towerCost[0], 0);
    }
    public void BasicTowerReturn()
    {
        select.Placement(towers[0]);
    }
    //sniper
    public void SniperTower()
    {
        bank.CentjesErAf(towerCost[1], 1);
    }
    public void SniperTowerReturn()
    {
        select.Placement(towers[1]);
    }
    //slow
    public void SlowTower()
    {
        bank.CentjesErAf(towerCost[2], 2);
    }
    public void SlowTowerReturn()
    {
        select.Placement(towers[2]);
    }
    //shotgun
    public void ShotgunTower()
    {
        bank.CentjesErAf(towerCost[3], 3);
    }
    public void ShotgunTowerReturn()
    {
        select.Placement(towers[3]);
    }
    //laser
    public void LaserTower()
    {
        bank.CentjesErAf(towerCost[4], 4);
    }
    public void LaserTowerReturn()
    {
        select.Placement(towers[4]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //sniper
    public void SniperTower()
    {
        bank.CentjesErAf(towerCost[1], 1);
    }
    //slow
    public void SlowTower()
    {
        bank.CentjesErAf(towerCost[2], 2);
    }
    //shotgun
    public void ShotgunTower()
    {
        bank.CentjesErAf(towerCost[3], 3);
    }
    //laser
    public void LaserTower()
    {
        bank.CentjesErAf(towerCost[4], 4);
    }
    //return
    public void Return(int i)
    {
        select.Placement(towers[i]);
    }
}

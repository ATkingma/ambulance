using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelect : MonoBehaviour
{
    private CubePlacer select;
    private Centjes bank;

    public List<float> towerCost;
    public List<Transform> towers;
    public GameObject audioSorce;

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
        audioSorce.GetComponent<AudioSource>().Play();
    }
    //sniper
    public void SniperTower()
    {
        bank.CentjesErAf(towerCost[1], 1);
        audioSorce.GetComponent<AudioSource>().Play();
    }
    //slow
    public void SlowTower()
    {
        bank.CentjesErAf(towerCost[2], 2);
        audioSorce.GetComponent<AudioSource>().Play();
    }
    //shotgun
    public void ShotgunTower()
    {
        bank.CentjesErAf(towerCost[3], 3);
        audioSorce.GetComponent<AudioSource>().Play();
    }
    //laser
    public void LaserTower()
    {
        bank.CentjesErAf(towerCost[4], 4);
        audioSorce.GetComponent<AudioSource>().Play();
    }
    //return
    public void Return(int i)
    {
        select.Placement(towers[i]);
    }
}

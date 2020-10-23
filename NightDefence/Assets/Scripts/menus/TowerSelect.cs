using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelect : MonoBehaviour
{
    private TowerPlacer select;
    private Centjes bank;

    public List<float> towerCost;
    public List<Transform> towers;
    public GameObject audioSorce;

    //tutorial
    private bool firstTime = true;

    private void Start()
    {
        select = FindObjectOfType<TowerPlacer>();
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
    //beam
    public void BeamTower()
    {
        bank.CentjesErAf(towerCost[5], 5);
        audioSorce.GetComponent<AudioSource>().Play();
    }
    //return
    public void Return(int i)
    {
        if (firstTime)
        {
            firstTime = false;
            FindObjectOfType<Tutorial>().NextLine();
        }
        select.Placement(towers[i]);
    }
}

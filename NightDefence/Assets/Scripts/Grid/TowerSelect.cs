using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelect : MonoBehaviour
{
    private CubePlacer select;

    public List<Transform> towers;

    private void Start()
    {
        select = FindObjectOfType<CubePlacer>();
        List<Transform> towers = new List<Transform>();
    }
    public void BasicTower()
    {
        select.Placement(towers[0]);
    }
    public void SniperTower()
    {
        select.Placement(towers[1]);
    }
    public void SlowTower()
    {
        select.Placement(towers[2]);
    }
    public void ShotgunTower()
    {
        select.Placement(towers[3]);
    }
    public void LazerTower()
    {
        select.Placement(towers[4]);
    }
}

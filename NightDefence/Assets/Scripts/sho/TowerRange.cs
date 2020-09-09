using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerRange : MonoBehaviour
{
    private Vector3 rangePosition;
    public List<GameObject> rangeIndecators;

    private void Start()
    {
        List<GameObject> rangeIndecators = new List<GameObject>();
    }
    private void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            rangePosition = FindObjectOfType<CubePlacer>().finalPosition;
        }
    }

    //basic
    public void Range_BasicOn()
    {
        rangeIndecators[0].SetActive(true);
        rangeIndecators[0].transform.position = rangePosition;
    }
    public void Range_BasicOff()
    {
        rangeIndecators[0].SetActive(false);
    }
    //sniper
    public void Range_SniperOn()
    {
        rangeIndecators[1].SetActive(true);
        rangeIndecators[1].transform.position = rangePosition;
    }
    public void Range_SniperOff()
    {
        rangeIndecators[1].SetActive(false);
    }
    //slow
    public void Range_SlowOn()
    {
        rangeIndecators[2].SetActive(true);
        rangeIndecators[2].transform.position = rangePosition;
    }
    public void Range_SlowOff()
    {
        rangeIndecators[2].SetActive(false);
    }
    //shotgun
    public void Range_shotgunOn()
    {
        rangeIndecators[3].SetActive(true);
        rangeIndecators[3].transform.position = rangePosition;
    }
    public void Range_ShotgunOff()
    {
        rangeIndecators[3].SetActive(false);
    }
    //laser
    public void Range_LaserOn()
    {
        rangeIndecators[4].SetActive(true);
        rangeIndecators[4].transform.position = rangePosition;
    }
    public void Range_LaserOff()
    {
        rangeIndecators[4].SetActive(false);
    }
}

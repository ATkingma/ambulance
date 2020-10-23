using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerInfo : MonoBehaviour
{
    public GameObject towerShop;
    public TextMeshProUGUI cost;

    public List<GameObject> infoList;

    private void Update()
    {
        if (towerShop.activeInHierarchy)
        {
            cost.gameObject.SetActive(true);
        }
        else
        {
            BasicInfo(false);
            SniperInfo(false);
            FreezeInfo(false);
            ShotgunInfo(false);
            LaserInfo(false);
            BeamInfo(false);
            cost.text = "";
            cost.gameObject.SetActive(false);
        } 
    }
    public void BasicInfo(bool info)
    {
        infoList[0].SetActive(info);
        cost.text = towerShop.GetComponent<TowerSelect>().towerCost[0].ToString();
    }
    public void SniperInfo(bool info)
    {
        infoList[1].SetActive(info);
        cost.text = towerShop.GetComponent<TowerSelect>().towerCost[1].ToString();
    }
    public void FreezeInfo(bool info)
    {
        infoList[2].SetActive(info);
        cost.text = towerShop.GetComponent<TowerSelect>().towerCost[2].ToString();
    }
    public void ShotgunInfo(bool info)
    {
        infoList[3].SetActive(info);
        cost.text = towerShop.GetComponent<TowerSelect>().towerCost[03].ToString();
    }
    public void LaserInfo(bool info)
    {
        infoList[4].SetActive(info);
        cost.text = towerShop.GetComponent<TowerSelect>().towerCost[4].ToString();
    }
    public void BeamInfo(bool info)
    {
        infoList[5].SetActive(info);
        cost.text = towerShop.GetComponent<TowerSelect>().towerCost[5].ToString();
    }
}

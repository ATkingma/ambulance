using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    public List<GameObject> infoList;

    public void BasicInfo(bool info)
    {
        infoList[0].SetActive(info);
    }
    public void SniperInfo(bool info)
    {
        infoList[1].SetActive(info);
    }
    public void FreezeInfo(bool info)
    {
        infoList[2].SetActive(info);
    }
    public void ShotgunInfo(bool info)
    {
        infoList[3].SetActive(info);
    }
    public void LaserInfo(bool info)
    {
        infoList[4].SetActive(info);
    }
}

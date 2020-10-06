using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerLevelUI : MonoBehaviour
{
    public GameObject tower;
    public TextMeshProUGUI text;

    void Update()
    {
        if(tower.GetComponent<TurretTargeting>() != null)
        {
            text.text = tower.GetComponent<TurretTargeting>().upgradeCount.ToString();
        }
        else
        {
            if(tower.GetComponent<LaserBeam>() != null)
            {
                text.text = tower.GetComponent<LaserBeam>().upgradeCount.ToString();
            }
            else
            {
                text.text = tower.GetComponent<LaserTargeting>().upgradeCount.ToString();
            }
        }
    }
}

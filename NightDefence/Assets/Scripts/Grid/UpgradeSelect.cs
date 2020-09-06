using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeSelect : MonoBehaviour
{
    private CubePlacer select;

    public List<TextMeshProUGUI> stats;

    private void Start()
    {
        select = FindObjectOfType<CubePlacer>();
        List<Transform> towers = new List<Transform>();
    }
    public void SelectedTowerInfo(GameObject tower)
    {
        stats[1].text = tower.GetComponent<TurretTargeting>().attacksPerSec.ToString();
        stats[0].text = tower.GetComponentInChildren<BasicTower>().end_Damage.ToString();
    }

    public void BasicTower_Damage()
    {
        select.CloseShop();
    }
}
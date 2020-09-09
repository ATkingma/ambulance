using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeSelect : MonoBehaviour
{
    private CubePlacer select;

    public List<TextMeshProUGUI> stats;
    private GameObject selectedTower;

    private void Start()
    {
        select = FindObjectOfType<CubePlacer>();
        List<Transform> towers = new List<Transform>();
    }
    public void SelectedTowerInfo(GameObject tower)
    {
        selectedTower = tower;
        stats[1].text = tower.GetComponent<TurretTargeting>().attacksPerSec.ToString() + " /sec";
        stats[0].text = tower.GetComponentInChildren<BasicTower>().end_Damage.ToString() + " Damage";
    }

    public void BasicTower_Damage()
    {
        FindObjectOfType<Centjes>().CentjesErAf(selectedTower.GetComponent<TurretTargeting>().upgradeCost, 10);
    }
    public void BasicTower_DamageReturn()
    {
        selectedTower.transform.parent.GetComponentInChildren<DamageCalculation>().AttackDamage_Basic();
        selectedTower.transform.parent.GetComponentInChildren<DamageCalculation>().AttackSpeed_Basic();

        select.CloseShop();
    }
}
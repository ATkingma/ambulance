using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacer : MonoBehaviour
{
    private Grid grid;

    private Transform select;
    public Vector3 finalPosition;

    public GameObject towerShop, upgradeShop, menuUI, sellPanel , gridCollider, cancelButton;
    public LayerMask placable;
    private bool uiIsON = false;
    private GameObject uiScript;
    public List<Vector3> towerPositions;

    private void Awake()
    {
        uiScript = FindObjectOfType<UIScript>().gameObject;
        List <Vector3> towerPositions = new List<Vector3>();
        grid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        if(uiIsON == false)
        {
            Raycast();
            gridCollider.GetComponent<BoxCollider>().enabled = true;
        }
        if (towerShop.activeInHierarchy || upgradeShop.activeInHierarchy || menuUI.activeInHierarchy || sellPanel.activeInHierarchy)
        {
            uiIsON = true;
            gridCollider.GetComponent<BoxCollider>().enabled = false;
            cancelButton.SetActive(true);
        }
        else
        {
            uiIsON = false;
            cancelButton.SetActive(false);
        }
    }

    public void Raycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            hitInfo = Physics.RaycastAll(Camera.main.transform.position, ray.direction);

            for (int i = 0; i < hitInfo.Length; i++)
            {
                RaycastHit hit = hitInfo[i];
                GameObject gObject = hit.transform.gameObject;
                if(EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                else
                {
                    if (gObject.tag == "Tower")
                    {
                        PlaceTower(hitInfo[i].point);
                        uiScript.GetComponent<UIScript>().UpgradeShopOn();
                        upgradeShop.GetComponent<UpgradeSelect>().SelectedTowerInfo(gObject.transform.parent.GetComponentInChildren<TurretTargeting>().gameObject);
                        gObject.transform.parent.GetComponentInChildren<TurretTargeting>().rangeOn = true;
                        gridCollider.GetComponent<BoxCollider>().enabled = false;
                    }
                    else
                    {
                        if (!upgradeShop.activeInHierarchy)
                        {
                            if (gObject.tag == "Grid")
                            {
                                PlaceTower(hitInfo[i].point);
                                if (!towerPositions.Contains(finalPosition))
                                {
                                    uiScript.GetComponent<UIScript>().TowerShopOn();
                                    gridCollider.GetComponent<BoxCollider>().enabled = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        Debugf();
    }

    #region placement
    private void PlaceTower(Vector3 clickPoint)
    {
        finalPosition = grid.GetNearestPointOnGrid(clickPoint);
    }
    public void Placement(Transform tower)
    {
        select = tower;
        Instantiate(select, finalPosition, Quaternion.identity);
        towerPositions.Add(finalPosition);
        uiScript.GetComponent<UIScript>().UIOff();
        uiScript.GetComponent<UIScript>().InGameUIOn();
    }
    #endregion
    #region upgrades
    public void CloseShop()
    {
        uiScript.GetComponent<UIScript>().UIOff();
        uiScript.GetComponent<UIScript>().InGameUIOn();
    }
    #endregion
    #region sell
    public void RemoveTower()
    {
        towerPositions.Remove(finalPosition);
    }
    #endregion
    public void Debugf()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 0.5f);
    }
}

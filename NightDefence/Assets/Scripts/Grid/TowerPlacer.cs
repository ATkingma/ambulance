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
    public Transform target;
    public Vector3 roof;
    private GameObject tagCheck;

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
        if (towerShop.activeInHierarchy || upgradeShop.activeInHierarchy || sellPanel.activeInHierarchy)
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
                    if (Input.GetMouseButtonDown(0))
                    {
                        PlaceTower(hitInfo[i].point);
                        uiScript.GetComponent<UIScript>().UpgradeShopOn();
                        if (gObject.transform.parent.tag == "LaserTower")
                        {
                            upgradeShop.GetComponent<UpgradeSelect>().SelectedTowerInfo(gObject.transform.parent.GetComponentInChildren<LaserTargeting>().gameObject);
                            gObject.transform.parent.GetComponentInChildren<LaserTargeting>().rangeOn = true;
                        }
                        else
                        {
                            upgradeShop.GetComponent<UpgradeSelect>().SelectedTowerInfo(gObject.transform.parent.GetComponentInChildren<TurretTargeting>().gameObject);
                            gObject.transform.parent.GetComponentInChildren<TurretTargeting>().rangeOn = true;
                        }
                        gridCollider.GetComponent<BoxCollider>().enabled = false;
                    }
                }
                else
                {
                    if (!upgradeShop.activeInHierarchy)
                    {
                        if (gObject.tag == "roof")
                        {
                            PlaceTower(hitInfo[i].point);
                            target.position = finalPosition;
                            if (!towerPositions.Contains(finalPosition))
                            {
                                if (Input.GetMouseButtonDown(0))
                                {
                                    uiScript.GetComponent<UIScript>().TowerShopOn();
                                    gridCollider.GetComponent<BoxCollider>().enabled = false;
                                    tagCheck = hit.transform.gameObject;
                                    print(tagCheck.name);
                                }
                            }
                        }
                        if (gObject.tag == "Grid")
                        {
                            PlaceTower(hitInfo[i].point);
                            target.position = finalPosition;
                            if (towerPositions.Contains(finalPosition))
                            {
                                if (Input.GetMouseButtonDown(0))
                                {
                                    uiScript.GetComponent<UIScript>().TowerShopOn();
                                    gridCollider.GetComponent<BoxCollider>().enabled = false;
                                    tagCheck = hit.transform.gameObject;
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
        if (tagCheck.tag == "Grid")
        {
            select = tower;
            Instantiate(select, finalPosition, Quaternion.identity);
            towerPositions.Remove(finalPosition);
            uiScript.GetComponent<UIScript>().UIOff();
            uiScript.GetComponent<UIScript>().InGameUIOn();
        }
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
        towerPositions.Add(finalPosition);
    }
    #endregion
    public void Debugf()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 0.5f);
    }
}

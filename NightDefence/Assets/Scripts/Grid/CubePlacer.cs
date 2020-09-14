﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;

    private Transform select;
    public Vector3 finalPosition;

    public GameObject towerShop, upgradeShop, gridCollider;
    public LayerMask placable;
    private bool uiIsON = false;

    public List<Vector3> towerPositions;

    private void Awake()
    {
        List<Vector3> towerPositions = new List<Vector3>();
        grid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        if(uiIsON == false)
        {
            Raycast();
        }
        if (towerShop.activeInHierarchy || upgradeShop.activeInHierarchy)
        {
            uiIsON = true;
        }
        else
        {
            uiIsON = false;
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
                if (gObject.tag == "Tower")
                {
                    upgradeShop.SetActive(true);
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
                                towerShop.SetActive(true);
                                gridCollider.GetComponent<BoxCollider>().enabled = false;
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
        //select = null;
        towerPositions.Add(finalPosition);
        towerShop.SetActive(false);
        gridCollider.GetComponent<BoxCollider>().enabled = true;
    }
    #endregion
    #region upgrades
    public void CloseShop()
    {
        upgradeShop.SetActive(false);
        towerShop.SetActive(false);
        gridCollider.GetComponent<BoxCollider>().enabled = true;
    }


    #endregion
    public void Debugf()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 0.5f);
    }
}

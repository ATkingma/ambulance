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

    public void Range_BasicOn()
    {
        rangeIndecators[0].SetActive(true);
        rangeIndecators[0].transform.position = rangePosition;
    }
    public void Range_BasicOff()
    {
        rangeIndecators[0].SetActive(false);
    }
}

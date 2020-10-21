using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centjes : MonoBehaviour
{
    public float startCentjes;
    public float centjes;

    private void Start()
    {
        CentjesErBij(startCentjes);
    }

    public void CentjesErBij(float plus)
    {
        centjes += plus;
    }
    public void CentjesErAf(float min, int shopNumber)
    {
        float dummy = centjes;
        dummy -= min;
        if(dummy >= 0)
        {
            centjes -= min;
            if (shopNumber < 10)
            {
                FindObjectOfType<TowerSelect>().Return(shopNumber);
            }

            if (shopNumber > 9)
            {
                FindObjectOfType<UpgradeSelect>().Return();
            }
        }
    }
    public void Centjes100()
    {
        CentjesErBij(100);
    }
    public void Centjes1000()
    {
        CentjesErBij(1000);
    }
    public void Centjes10000()
    {
        CentjesErBij(10000);
    }
}

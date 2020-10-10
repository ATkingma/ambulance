using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthSlider : MonoBehaviour
{
    public GameObject baze;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = baze.GetComponent<HealthScript>().health;
        healthSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = baze.GetComponent<HealthScript>().health;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthSlider : MonoBehaviour
{
    public GameObject mainCamera,enemy;
    public Slider healthSlider;
    
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        healthSlider.maxValue = enemy.GetComponent<HealthScript>().health;
        healthSlider.minValue = 0;
    }
    void Update()
    {
        transform.LookAt(mainCamera.transform.position);
        healthSlider.value = enemy.GetComponent<HealthScript>().health;
    }
}

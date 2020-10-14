using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public float time;
    public Slider slider;
    public int scene;
    void Start()
    {
        slider.maxValue = 5000;
        slider.minValue = 0;
    }
    void Update()
    {
        if (time >= 5000)
        {
            SceneManager.LoadScene(scene);
        }
        slider.value = time;
        Counter();
    }
    public void Counter()
    {
        time++;
    }
}
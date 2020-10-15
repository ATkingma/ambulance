using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public float time;
    public Slider slider;
    public Text boelshitAdvice;
    public int scene, randomTeacher,maxLines,currentLine;
    public  string []advice;
    public GameObject sliderHandel;
    public GameObject[] teacherList;
    void Start()
    {
        slider.maxValue = 5000;
        slider.minValue = 0;
        PickNextLine();
        GenRandom();
        sliderHandel.GetComponent<Image>().sprite = teacherList[randomTeacher].GetComponent<Image>().sprite;
    }
    public void GenRandom()
    {
        randomTeacher = Random.Range(0, 4);
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
    public void PickNextLine()
    {
        if (currentLine >= maxLines)
        {
            currentLine = 0;
        }
        if (currentLine == maxLines)
        {
            currentLine = 0;
        }
        currentLine++;
        ShowNextLine();
    }
    public void ShowNextLine()
    {
        boelshitAdvice.text = advice[currentLine].ToString();
        Invoke("PickNextLine", 2.5f);
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject loadingScreen;
    public TextMeshProUGUI text;
    public bool endLoadingScreen;
    void Start()
    {
        if (endLoadingScreen == true)
        {
        slider.maxValue = 5000;
        slider.minValue = 0;
        }
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
        if (endLoadingScreen == true)
        {
            if (time >= 5000)
            {
                SceneManager.LoadScene(scene);
            }
            slider.value = time;
        Counter();
        }

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
    public void StartLoadingScreen()
    {
        StartCoroutine(LoadSceneEnumerator());
    }
    IEnumerator LoadSceneEnumerator()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            text.text = progress * 100f + "%";
            yield return null;
        }
    }
}
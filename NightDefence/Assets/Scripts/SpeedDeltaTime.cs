using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDeltaTime : MonoBehaviour
{
    private bool pause;
    public GameObject pauze, play;
    public float ditWasTimeScale;

    private void Start()
    {
        ditWasTimeScale = 1;
    }

    public void Keer1()
    {
        Time.timeScale = 1;
        ditWasTimeScale = 1;
    }
    public void Keer2()
    {
        Time.timeScale = 2;
        ditWasTimeScale = 2;
    }
    public void Keer15()
    {
        Time.timeScale = 1.5f;
        ditWasTimeScale = 1.5f;
    }
    public void Keer5()
    {
        Time.timeScale = 5f;
        ditWasTimeScale = 5f;
    }
    public void Keer10()
    {
        Time.timeScale = 10f;
        ditWasTimeScale = 10f;
    }
    public void Keer115()
    {
        Time.timeScale = 15f;
        ditWasTimeScale = 15f;
    }
    public void Pause()
    {
        pause=!pause;
        if (pause == true)
        {
            Time.timeScale = 0;
            pauze.SetActive(false);
            play.SetActive(true);
        }
        if (pause == false)
        {
            Time.timeScale = ditWasTimeScale;
            play.SetActive(false);
            pauze.SetActive(true);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDeltaTime : MonoBehaviour
{
    private bool pause;
    public GameObject pauze, play;

    public void Keer1()
    {
        Time.timeScale = 1;
        FindObjectOfType<Saves>().SaveTimeScale();
    }
    public void Keer2()
    {
        Time.timeScale = 2;
        FindObjectOfType<Saves>().SaveTimeScale();
    }
    public void Keer15()
    {
        Time.timeScale = 1.5f;
        FindObjectOfType<Saves>().SaveTimeScale();
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
            Time.timeScale = PlayerPrefs.GetFloat("timeScale", 1);
            play.SetActive(false);
            pauze.SetActive(true);
        }
    }
}

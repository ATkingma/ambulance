﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDeltaTime : MonoBehaviour
{
    private bool pause;
    public GameObject pauze, play;
    public void Keer1()
    {
        Time.timeScale = 1;
    }
    public void Keer2()
    {
        Time.timeScale = 2;
    }
    public void Keer15()
    {
        Time.timeScale = 1.5f;
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
            Time.timeScale = 1;
            play.SetActive(false);
            pauze.SetActive(true);
        }
    }
}

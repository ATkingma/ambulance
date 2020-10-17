using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saves : MonoBehaviour
{
    public List<float> audioSaves;

    private void Start()
    {
        List<float> audioSaves = new List<float>(1000);
    }
    public void SaveEveryFuckingThing()
    {
        audioSaves[0] = FindObjectOfType<AudioManager>().savedValue[0];
        audioSaves[1] = FindObjectOfType<AudioManager>().savedValue[1];
        audioSaves[2] = FindObjectOfType<AudioManager>().savedValue[2];
        audioSaves[3] = FindObjectOfType<AudioManager>().savedValue[3];

        PlayerPrefs.SetFloat("mastervalue", audioSaves[0]);
        PlayerPrefs.SetFloat("sfxvalue", audioSaves[1]);
        PlayerPrefs.SetFloat("musicvalue", audioSaves[2]);
        PlayerPrefs.SetFloat("uivalue", audioSaves[3]);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saves : MonoBehaviour
{
    public List<float> audioSaves;

    public void SaveEveryFuckingThing(float ooga1,float ooga2,float ooga3,float ooga4)
    {
        audioSaves[0] = ooga1;
        audioSaves[1] = ooga2;
        audioSaves[2] = ooga3;
        audioSaves[3] = ooga4;

        PlayerPrefs.SetFloat("mastervalue", audioSaves[0]);
        PlayerPrefs.SetFloat("sfxvalue", audioSaves[1]);
        PlayerPrefs.SetFloat("musicvalue", audioSaves[2]);
        PlayerPrefs.SetFloat("uivalue", audioSaves[3]);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer _MasterMixer;

    public List<float> savedValue;

    private void Start()
    {
        List<float> savedValue = new List<float>(1000)
        {
            [0] = PlayerPrefs.GetFloat("masterValue", 100),
            [1] = PlayerPrefs.GetFloat("sfxValue", 100),
            [2] = PlayerPrefs.GetFloat("musicValue", 100),
            [3] = PlayerPrefs.GetFloat("uiValue", 100)
        };
    }

    public void SetMasterVolume(Slider volume)
    {
        _MasterMixer.SetFloat("master", volume.value);
    }
    public void SetSFXVolume(Slider volume)
    {
        _MasterMixer.SetFloat("sfx", volume.value);
    }
    public void SetMusicVolume(Slider volume)
    {
        _MasterMixer.SetFloat("music", volume.value);
    }
    public void SetUIVolume(Slider volume)
    {
        _MasterMixer.SetFloat("ui", volume.value);
    }
}

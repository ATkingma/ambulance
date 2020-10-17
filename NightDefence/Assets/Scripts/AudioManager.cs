using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer _MasterMixer;

    public List<float> savedValue;

    public void Start()
    {
        savedValue[0] = PlayerPrefs.GetFloat("master", 0);
        savedValue[1] = PlayerPrefs.GetFloat("sfxValue", 0);
        savedValue[2] = PlayerPrefs.GetFloat("musicValue", 0);
        savedValue[3] = PlayerPrefs.GetFloat("uiValue", 0);

        _MasterMixer.SetFloat("master", savedValue[0]);
        _MasterMixer.SetFloat("sfxValue", savedValue[1]);
        _MasterMixer.SetFloat("musicValue", savedValue[2]);
        _MasterMixer.SetFloat("uiValue", savedValue[3]);
    }

    public void SetMasterVolume(Slider volume)
    {
        _MasterMixer.SetFloat("master", volume.value);
        FindObjectOfType<Saves>().SaveEveryFuckingThing();
    }
    public void SetSFXVolume(Slider volume)
    {
        _MasterMixer.SetFloat("sfx", volume.value);
        FindObjectOfType<Saves>().SaveEveryFuckingThing();
    }
    public void SetMusicVolume(Slider volume)
    {
        _MasterMixer.SetFloat("music", volume.value);
        FindObjectOfType<Saves>().SaveEveryFuckingThing();
    }
    public void SetUIVolume(Slider volume)
    {
        _MasterMixer.SetFloat("ui", volume.value);
        FindObjectOfType<Saves>().SaveEveryFuckingThing();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer _MasterMixer;
    public AudioMixerGroup masterVolume;

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

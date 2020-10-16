using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuScript : MonoBehaviour
{
    public GameObject options, credits,mainMenu, controlls,hover,x;
    Resolution[] resolutions;
    public Dropdown resolutionDropDown;
    public void Start()
    {
        resolutions=Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i <resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
              currentResolutionIndex=i;
            }
        }   
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
         SceneManager.LoadScene(1);
    }
    public void Options()
    {
        UiOff();
        options.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Credits()
    {
        UiOff();
        credits.SetActive(true);
    }
    public void Main()
    {
        UiOff();
        mainMenu.SetActive(true);
    }
    public void Control()
    {
        UiOff();
        controlls.SetActive(true);
    }
    public void UiOff()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        credits.SetActive(false);
        controlls.SetActive(false);
    }
    public void PlayerHover()
    {
        hover.GetComponent<AudioSource>().Play();
    }
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen == true)
        {
            x.SetActive(true);
        }
        if (isFullscreen == false)
        {
            x.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public GameObject options, credits,mainMenu, controlls,hover;
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
}
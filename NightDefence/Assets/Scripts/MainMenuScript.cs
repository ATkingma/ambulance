using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject options, credits;
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        UiOff();
        options.SetActive(true);
    }
    public void Credits()
    {
        UiOff();
        credits.SetActive(true);
    }
    public void UiOff()
    {
        options.SetActive(false);
        credits.SetActive(false);
    }
}

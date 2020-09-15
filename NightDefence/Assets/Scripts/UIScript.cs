using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text money, baseHP, EnemiesAlive;
    public int wave, enemiesAlive;
    public GameObject basis,ingameUi,InGameMenu,GameManager;
    public bool escape;
    public void Update()
    {
        InGameUIUpdate();
        if (Input.GetButtonDown("Esc"))
        {
            ESCMenu();
            print("koek");
        }
    }
    public void InGameUIUpdate()
    {
        wave = GameManager.GetComponent<WaveScript>().waveCount;
        money.text = GameManager.GetComponent<Centjes>().centjes.ToString();
        enemiesAlive = GameManager.GetComponent<WaveScript>().maxEnemies - GameManager.GetComponent<WaveScript>().enemiesDied;
        EnemiesAlive.text = enemiesAlive.ToString();
        baseHP.text = basis.GetComponent<HealthScript>().health.ToString();
    }
    public void ESCMenu()
    {
        if (escape == false)
        {
            ingameUi.gameObject.SetActive(false);
            InGameMenu.gameObject.SetActive(true);
            escape = true;
        }
        if (escape == true)
        {
            InGameMenu.gameObject.SetActive(false);
            ingameUi.gameObject.SetActive(true);
            escape = false;
        }
    }
    public void Options()
    {
      
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
      Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text money, baseHP, EnemiesAlive;
    public int wave, enemiesAlive;
    public GameObject basis, ingameUi, inGameMenu, towerShop, upgradeShop, GameManager;
    public bool toggle;


    public void Update()
    {
        InGameUIUpdate();
        EscapeButton();
    }

    public void EscapeButton()
    {
        if (Input.GetButtonDown("Esc"))
        {
            ESCMenu();
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
        UIOff();
        InGameMenuOn();
        Toggle();
    }
    //buttons
    public void Options()
    {

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //toggles
    public void Toggle()
    {
        toggle = !toggle;
    }
    #region uiOn
    public void InGameUIOn()
    {
        UIOff();
        ingameUi.SetActive(true);
    }
    public void InGameMenuOn()
    {
        UIOff();
        if (toggle == false)
        {
            inGameMenu.SetActive(true);
        }
        else
        {
            InGameUIOn();
        }
    }
    public void TowerShopOn()
    {
        UIOff();
        InGameUIOn();
        towerShop.SetActive(true);
    }
    public void UpgradeShopOn()
    {
        UIOff();
        InGameUIOn();
        upgradeShop.SetActive(true);
    }
    #endregion
    public void UIOff()
    {
        ingameUi.SetActive(false);
        inGameMenu.SetActive(false);
        towerShop.SetActive(false);
        upgradeShop.SetActive(false);
    }

    public void QuitGame()
    {
      Application.Quit();
    }
}
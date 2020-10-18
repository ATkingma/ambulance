using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text money, baseHP, enemiesAliveText, waveCount;
    public int wave, enemiesAlive;
    public GameObject basis, ingameUi, inGameMenu, towerShop, upgradeShop, sellPanel, GameManager, optionsMenu;
    public bool toggle;

    private void Start()
    {
        wave = 1;
        basis = GameObject.FindWithTag("Base");
    }
    private void Update()
    {
        InGameUIUpdate();
        EscapeButton();
    }
    public void Resume()
    {
        ESCMenu();
        Time.timeScale = 1;
    }
    public void EscapeButton()
    {
        if (Input.GetButtonDown("Esc"))
        {
            if(towerShop.activeInHierarchy || upgradeShop.activeInHierarchy)
            {
                EscWhiletowershop();
            }
            else
            {
                ESCMenu();
            }
        }
    }
    public void InGameUIUpdate()
    {
        wave = GameManager.GetComponent<WaveScript>().waveCount;
        money.text = GameManager.GetComponent<Centjes>().centjes.ToString();
        enemiesAlive = GameManager.GetComponent<WaveScript>().maxEnemies - GameManager.GetComponent<WaveScript>().enemiesDied;
        enemiesAliveText.text = enemiesAlive.ToString();
        baseHP.text = basis.GetComponent<HealthScript>().health.ToString();
        waveCount.text = wave.ToString();
    }
    public void ESCMenu()
    {
        if(inGameMenu.activeInHierarchy == false && optionsMenu.activeInHierarchy == false)
        {
            UIOff();
            inGameMenu.SetActive(true);
            FindObjectOfType<SpeedDeltaTime>().ditWasTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            inGameMenu.SetActive(false);
            ingameUi.SetActive(true);
            Time.timeScale = FindObjectOfType<SpeedDeltaTime>().ditWasTimeScale;
            if (optionsMenu.activeInHierarchy == false)
            {
                return;

            }
            else
            {
                optionsMenu.SetActive(false);
                inGameMenu.SetActive(true);
            }
        }
    }
    //buttons
    public void Options()
    {
        UIOff();
        optionsMenu.SetActive(true);
    }
    public void OptionsBackToMenu()
    {
        UIOff();
        inGameMenu.SetActive(true);
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
            Toggle();
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
    public void SellMenuOn()
    {
        sellPanel.SetActive(true);
        upgradeShop.SetActive(false);
    }
    public void SellMenuOff()
    {
        sellPanel.SetActive(false);
        upgradeShop.SetActive(true);
    }
    #endregion
    public void UIOff()
    {
        ingameUi.SetActive(false);
        inGameMenu.SetActive(false);
        towerShop.SetActive(false);
        upgradeShop.SetActive(false);
        sellPanel.SetActive(false);
        optionsMenu.SetActive(false);
    }
    public void EscWhiletowershop()
    {
        towerShop.SetActive(false);
        upgradeShop.SetActive(false);
    }

    public void QuitGame()
    {
      Application.Quit();
    }
}
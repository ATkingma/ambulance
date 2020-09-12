using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text money, baseHP, EnemiesAlive;
    public int wave, enemiesAlive;
    public GameObject basis;
    public void Update()
    {
        wave = gameObject.GetComponent<WaveScript>().waveCount;
        money.text = gameObject.GetComponent<Centjes>().centjes.ToString();
        enemiesAlive = gameObject.GetComponent<WaveScript>().waves[wave].enemies[0].amount + gameObject.GetComponent<WaveScript>().waves[wave].enemies[1].amount + gameObject.GetComponent<WaveScript>().waves[wave].enemies[2].amount;
        EnemiesAlive.text = enemiesAlive.ToString();
        baseHP.text = basis.GetComponent<HealthScript>().health.ToString();
    }
}
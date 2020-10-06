using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WaveScript : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int WaveTime;
        public Enemies[] enemies;
        public bool[] enemiePrefabAmount;
    }
    [System.Serializable]
    public class Enemies
    {
        public GameObject enemiePrefab;
        public float spawnRate;
        public int amount, NextRoundCount;
        public bool amountChanged;
    }
    public Wave[] waves;
    public GameObject spawnPoint, button,beginButt, newRoundSound;
    public int maxWave, waveCount, prevuisWaveCount, maxEnemies, enemiesDied, roundCoolDown, roundCoolDownMore;
    public float[] nextSpawn;
    public bool resettingRound, checkedAgain, amountIsChanging, isNextMap, SpawnEnemies, skipPressed, beginButton;

    public void BeginButton()
    {
        beginButton = true;
        beginButt.SetActive(false);
    }
    public void Button()
    {
        Cooldown();
        skipPressed = true;
        Invoke("SkipButtonPressed", roundCoolDownMore);
    }
    public void EnemieSpawner()
    {
        if (beginButton == true)
        { 
            if (resettingRound == false)
            {
                if (waves[waveCount].enemiePrefabAmount[0] == true)
                {
                    if (Time.time > nextSpawn[0])
                    {
                        if (waves[waveCount].enemies[0].amount > 0)
                        {
                            Instantiate(waves[waveCount].enemies[0].enemiePrefab, spawnPoint.transform.position, Quaternion.identity);
                            nextSpawn[0] = Time.time + waves[waveCount].enemies[0].spawnRate;
                            waves[waveCount].enemies[0].amount--;
                        }
                    }
                }
                if (waves[waveCount].enemiePrefabAmount[1] == true)
                {
                    if (Time.time > nextSpawn[1])
                    {
                        if (waves[waveCount].enemies[1].amount > 0)
                        {
                            Instantiate(waves[waveCount].enemies[1].enemiePrefab, spawnPoint.transform.position, Quaternion.identity);
                            nextSpawn[1] = Time.time + waves[waveCount].enemies[1].spawnRate;
                            waves[waveCount].enemies[1].amount--;
                        }
                    }
                }
                if (waves[waveCount].enemiePrefabAmount[2] == true)
                {
                    if (Time.time > nextSpawn[2])
                    {
                        if (waves[waveCount].enemies[2].amount > 0)
                        {
                            Instantiate(waves[waveCount].enemies[2].enemiePrefab, spawnPoint.transform.position, Quaternion.identity);
                            nextSpawn[2] = Time.time + waves[waveCount].enemies[2].spawnRate;
                            waves[waveCount].enemies[2].amount--;
                        }
                    }
                }
            }
        }
    }
    public void FixedUpdate()
    {
        EndRoundCheck();

        EnemieSpawner();
        MaxWaveCheck();
        if (checkedAgain == true)
        {
            EnemieAmountCounting();
        }
    }
    private void MaxWaveCheck()
    {
        if (maxWave == waveCount)
        {
            if (isNextMap == true)
            {
                resettingRound = true;
                SceneManager.LoadScene(2);

            }
            if (isNextMap == false)
            {
                resettingRound = true;
                SceneManager.LoadScene(2);
            }
        }
    }
    private void EnemieAmountCounting()
    {
        checkedAgain = false;
        if (waves[waveCount].enemiePrefabAmount[0] == true)
        {
            maxEnemies += waves[waveCount].enemies[0].amount;
            waves[waveCount].enemies[0].NextRoundCount += waves[waveCount].enemies[0].amount;
        }
        if (waves[waveCount].enemiePrefabAmount[1] == true)
        {
            maxEnemies += waves[waveCount].enemies[1].amount;
            waves[waveCount].enemies[1].NextRoundCount += waves[waveCount].enemies[1].amount;
        }
        if (waves[waveCount].enemiePrefabAmount[2] == true)
        {
            maxEnemies += waves[waveCount].enemies[2].amount;
            waves[waveCount].enemies[2].NextRoundCount += waves[waveCount].enemies[2].amount;
        }
    }
    public void Start()
    {
        beginButt.SetActive(true);
        EnemieAmountCounting();
        prevuisWaveCount -= 1;
        roundCoolDownMore=roundCoolDown + 5;
        button.SetActive(false);
    }
    public void EndRoundCheck()
    {
        if (maxEnemies == enemiesDied)
        {
            if (resettingRound == false)
            {
                Reset();
            }
        }
    }
    public void SkipButtonPressed()
    {
        skipPressed = false;
    }
    public void Reset()
    {
        button.SetActive(true);
        resettingRound = true;
        maxEnemies = 0;
        enemiesDied = 0;
        Invoke("Cooldown", roundCoolDown);
    }
    public void Cooldown()
    {
        if (skipPressed == false)
        {
            checkedAgain = true;
            Invoke("MoreEnemies", 0.3f);
            Invoke("ResetBoolHolder", 1.0f);
            waveCount++;
            prevuisWaveCount++;
            newRoundSound.GetComponent<AudioSource>().Play();
            button.SetActive(false);
        }
    }
    public void AmountChange()
    {
        checkedAgain = false;
        if (waves[waveCount].enemiePrefabAmount[0] == true)
        {
            if (waves[waveCount].enemies[0].amountChanged == false)
            {
                waves[waveCount].enemies[0].NextRoundCount += 10;
            }
        }
        if (waves[waveCount].enemiePrefabAmount[1] == true)
        {
            if (waves[waveCount].enemies[1].amountChanged == false)
            {
                waves[waveCount].enemies[1].NextRoundCount += 5;
            }
        }
        if (waves[waveCount].enemiePrefabAmount[2] == true)
        {
            if (waves[waveCount].enemies[2].amountChanged == false)
            {
                waves[waveCount].enemies[2].NextRoundCount += 5;
            }
        }
        amountIsChanging = true;
    }
    public void ResetBoolHolder()
    {
        resettingRound = false;
    }
    public void MoreEnemies()
    {
        if (waves[waveCount].enemiePrefabAmount[0] == true)
        {
            if (waves[waveCount].enemies[0].amountChanged == false)
            {
                maxEnemies += waves[prevuisWaveCount].enemies[0].NextRoundCount;
                waves[waveCount].enemies[0].amount += waves[prevuisWaveCount].enemies[0].NextRoundCount;
            }
        }
        if (waves[waveCount].enemiePrefabAmount[1] == true)
        {
            if (waves[waveCount].enemies[1].amountChanged == false)
            {
                maxEnemies += waves[prevuisWaveCount].enemies[1].NextRoundCount;
                waves[waveCount].enemies[1].amount += waves[prevuisWaveCount].enemies[1].NextRoundCount;
            }
        }
        if (waves[waveCount].enemiePrefabAmount[2] == true)
        {
            if (waves[waveCount].enemies[2].amountChanged == false)
            {
                maxEnemies += waves[prevuisWaveCount].enemies[2].NextRoundCount;
                waves[waveCount].enemies[2].amount += waves[prevuisWaveCount].enemies[2].NextRoundCount;
            }
        }
    }
}
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
        public int amount,NextRoundCount;
        public bool amountChanged;
    }
    public Wave[] waves;
    public GameObject spawnPoint;
    public int maxWave,waveCount,prevuisWaveCount,maxEnemies,enemiesDied,roundCoolDown;
    public float[] nextSpawn;
    public bool resettingRound, checkedAgain, amountIsChanging, isNextMap;
    public void EnemieSpawner()
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
    public void Update()
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
                SceneManager.LoadScene(1);
            }
            if (isNextMap == false)
            {
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
        EnemieAmountCounting();
        prevuisWaveCount -= 1;
    }
    public void EndRoundCheck()
    {
        if (maxEnemies == enemiesDied)
        {
            if (resettingRound == false)
            {
                StartCoroutine(ResetRound());
            }
        }
    }
    public IEnumerator ResetRound()
    {
        resettingRound = true;
        maxEnemies = 0;
        enemiesDied = 0;
        yield return new WaitForSeconds(roundCoolDown);
        AmountChange();
        checkedAgain = true;
        Invoke("MoreEnemies", 0.3f);   
        Invoke("ResetBoolHolder", 1.0f);
        waveCount++;
        prevuisWaveCount++;
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
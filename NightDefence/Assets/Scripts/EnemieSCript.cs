using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemieSCript : MonoBehaviour
{
    public List<GameObject> locations;
    public GameObject endLocation, basehp;
    public int index, damage, MaxDestinations;
    public float burningDamage, enemieHealth;
    public bool Plus1, burn, givingVaraible;
    public GameObject[] gameManager;
    private float speed;
    public GameObject slowParticles;

    private void Start()
    {
        locations.AddRange(GameObject.FindGameObjectsWithTag("Des1"));
        locations.AddRange(GameObject.FindGameObjectsWithTag("Des2"));
        locations.AddRange(GameObject.FindGameObjectsWithTag("Des3"));
        locations.AddRange(GameObject.FindGameObjectsWithTag("Des4"));
        locations.AddRange(GameObject.FindGameObjectsWithTag("Des5"));
        locations.AddRange(GameObject.FindGameObjectsWithTag("Des6"));
        locations.AddRange(GameObject.FindGameObjectsWithTag("Des7"));
        gameManager = GameObject.FindGameObjectsWithTag("GameManager");
        speed = gameObject.GetComponent<NavMeshAgent>().speed;
        slowParticles.SetActive(false);
    }
    void FixedUpdate()
    {
        enemieHealth = gameObject.GetComponent<HealthScript>().health;
        if (burn == true)
        {
            gameObject.GetComponent<HealthScript>().health -= burningDamage * Time.deltaTime;
        }
        if (enemieHealth <= 0)
        {
            StartCoroutine(DeadEnemie());
        }
        if (index < MaxDestinations)
        {
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = locations[index].transform.position;
        }
    }
    public IEnumerator IndexPlus()
    {
        Plus1 = true;
        index++;
        yield return new WaitForSeconds(0.5f);
        Plus1 = false;
    }
    public void EindPos()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = endLocation.transform.position;
    }
    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.transform.tag == "Des")
        {
            if (Plus1 == false)
            {
                if (index < MaxDestinations)
                {
                    StartCoroutine(IndexPlus());
                }
                if (index == MaxDestinations)
                {
                    EindPos();
                }
            }
        }
        if (trigger.gameObject.transform.tag == "EndPos")
        {
            StartCoroutine(EndDesDestroy());
        }
    }
    public IEnumerator EndDesDestroy()
    {

        //hier miss geld weg halen ook ;)

        basehp.GetComponent<HealthScript>().DoDamage(damage, default);
        if (givingVaraible == false)
        {
            GiveVariableToWaveScript();
        }
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    public IEnumerator DeadEnemie()
    {
        //ergens count dr bij op zodat die checked dat alle enemies dood zijn
        // animatie dede
        //geld meer
        // bool aan
        if (givingVaraible == false)
        {
            GiveVariableToWaveScript();
        }
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

    }
    public void FreezeEnemie(float slowAmount, bool slow)
    {
        if (slow == true)
        {
            slowParticles.SetActive(true);
            float cooldown = 0;
            if (Time.time == cooldown + Time.time)
            {
                gameObject.GetComponent<NavMeshAgent>().speed = Mathf.Clamp(gameObject.GetComponent<NavMeshAgent>().speed *= slowAmount, 1, 10);
                cooldown = 5;
                Invoke("SpeedToNormal",cooldown);
            }
        }
    }
    public void SpeedToNormal()
    {
        gameObject.GetComponent<NavMeshAgent>().speed = speed;
        slowParticles.SetActive(false);
    }
    public void GiveVariableToWaveScript()
    {
        givingVaraible = true;
        gameManager[0].GetComponent<WaveScript>().enemiesDied++;

    }
}

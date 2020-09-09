using UnityEngine;
using UnityEngine.AI;

public class BigEnemieScriptExtra : MonoBehaviour
{
    public Animator anim;
    void Update()
    {
        if (gameObject.GetComponent<HealthScript>().health <= 300)
        {
            anim.SetBool("Running", true);
            gameObject.GetComponent<NavMeshAgent>().speed = 3;
        }
    }
}
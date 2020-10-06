using UnityEngine;
using UnityEngine.AI;

public class BigEnemieScriptExtra : MonoBehaviour
{
    private float hp;
    public Animator anim;
    private void Start()
    {
        hp += gameObject.GetComponent<HealthScript>().health;
        hp /= 2;
    }
    void Update()
    {
        if (gameObject.GetComponent<HealthScript>().health <= hp)
        {
            anim.SetBool("Running", true);
            gameObject.GetComponent<NavMeshAgent>().speed = 3;
        }
    }
}
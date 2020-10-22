using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotate : MonoBehaviour
{
    public Vector3 speed;
    private float stutter;

    private void Start()
    {
        stutter = speed.y;
        Stutter();
    }
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
        
        if(SceneManager.GetActiveScene().name == "LVL2")
        {
            transform.Rotate(speed * Time.deltaTime);
        }
    }
    public void Stutter()
    {
        speed.y = 0;
        Invoke("Stutter2", 0.5f);
    }
    public void Stutter2()
    {
        speed.y = stutter;
        Invoke("Stutter", Random.Range(1, 10));
    }
}

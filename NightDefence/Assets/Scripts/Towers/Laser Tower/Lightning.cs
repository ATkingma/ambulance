using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public Material normal, normal2;

    private void Start()
    {
        True();
    }
    public void True()
    {
        transform.GetComponent<LineRenderer>().material = normal;
        Invoke("False", 0.1f);
    }
    public void False()
    {
        transform.GetComponent<LineRenderer>().material = normal2;
        Invoke("True", 0.1f);
    }
}

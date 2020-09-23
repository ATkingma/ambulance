using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BariaerAnim : MonoBehaviour
{
    public Vector2 ofSetDing;
    public float OffSet;
    void Update()
    {
        OffSet += Time.deltaTime;
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, -OffSet));

    }
}
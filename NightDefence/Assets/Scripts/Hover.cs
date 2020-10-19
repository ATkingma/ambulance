using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public GameObject hover;
    public void PlayerHover()
    {
        hover.GetComponent<AudioSource>().Play();
    }
}

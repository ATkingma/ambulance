using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowCheats : MonoBehaviour
{
    public GameObject text;
    public Text cheatText;
    private bool shows;
    void Start()
    {
        text.SetActive(false);
    }
    void Update()
    {
        cheatText.text = gameObject.GetComponent<CheatCodeManager>().currentString;
        if (Input.GetKeyDown(KeyCode.F12))
        {
            shows = !shows;
        }
        if (shows == true)
        {
            text.SetActive(true);
        }
        if (shows == false)
        {
            text.SetActive(false);
        }
    }
    public void LoadLvl1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLvl2()
    {
        SceneManager.LoadScene(2);
    }
}

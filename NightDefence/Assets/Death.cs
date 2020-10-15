using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject loader;
    void Start()
    {
        Invoke("LevelLoader", 10);
    }
    public void LevelLoader()
    {
        loader.GetComponent<LoadingScreen>().StartLoadingScreen();
    }
}

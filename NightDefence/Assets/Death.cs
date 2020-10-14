using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public int scene;
    void Start()
    {
        Invoke("LevelLoader", 10);
    }
    public void LevelLoader()
    {
        SceneManager.LoadScene(scene);
    }
}

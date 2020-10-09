
using UnityEngine.SceneManagement;
using UnityEngine;
public class BaseScript : MonoBehaviour
{
    public int Scene;
    void Update()
    {
        if (gameObject.GetComponent<HealthScript>().health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}

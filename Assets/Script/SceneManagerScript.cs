using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadScene()
    {
        Invoke(nameof(Load), 0.2f);
        
    }

    private void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

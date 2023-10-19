using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public void LoadMenu()
    {
        Invoke(nameof(Menu), 0.2f);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Invoke(nameof(LoadExitGame), 0.2f);
    }
    public void LoadExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

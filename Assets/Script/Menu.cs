using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    private int levelnr;
    private void Load()
    {
        SceneManager.LoadScene(levelnr);
    }
    public void LoadLevel(int level)
    {
        levelnr=level;
        Invoke(nameof(Load), 0.2f);
    }
}

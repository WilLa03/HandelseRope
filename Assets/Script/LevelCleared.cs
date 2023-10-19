using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCleared : MonoBehaviour
{
    public void LevelDone()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}

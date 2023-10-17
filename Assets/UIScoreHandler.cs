using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreHandler : MonoBehaviour
{
    private List<Image> images = new List<Image>();

    private void Awake()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            images.Add(transform.GetChild(i).GetComponent<Image>());
        }
    }

    public void AddScore()
    {
        images[0].color=Color.white;
        images.Remove(images[0]);
    }
}

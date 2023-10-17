using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private ScorePoint score;
    private void OnTriggerEnter2D(Collider2D other)
    {
        score.Raise();
        Debug.Log("Score");
        Destroy(gameObject);
    }
}


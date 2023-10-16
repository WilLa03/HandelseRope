using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    [SerializeField] private HitBowl hitBowl;
    private void OnTriggerEnter2D(Collider2D other)
    {
        hitBowl.Raise();
    }
}

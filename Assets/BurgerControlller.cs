using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerControlller : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(rb.velocity.y);
    }

    public void RemoveBurger()
    {
        Destroy(gameObject);
    }
}

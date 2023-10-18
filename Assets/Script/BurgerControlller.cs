using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerControlller : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool gravity;
    [SerializeField]private float InverseGravityScale;
    private float GravityScale;
    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        GravityScale = rb.gravityScale;
    }

    private void Update()
    {
        if (rb.velocity.y > 1f)
        {
            rb.velocity = new Vector2(rb.velocity.x,1f);
        }
        else if (rb.velocity.y < -2f)
        {
            rb.velocity = new Vector2(rb.velocity.x,-2f);
        }
    }

    public void ChangeGravity()
    {
        if (!gravity)
        {
            rb.gravityScale = InverseGravityScale;
            rb.velocity = new Vector2(rb.velocity.x, 1f);
            gravity = true;
        }
        else
        {
            rb.gravityScale = GravityScale;
            gravity = false;
        }
    }

    public void RemoveBurger()
    {
        Destroy(gameObject);
    }
}

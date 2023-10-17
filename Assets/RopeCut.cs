using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCut : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera camera;

    [SerializeField] private CutRope cutrope;
    private Collider2D _collider2D;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera= Camera.main;
        _collider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.position = camera.ScreenToWorldPoint(Input.mousePosition);
            Invoke(nameof(trail), 0.05f);
            _collider2D.enabled = true;
        }
        else
        {
            _collider2D.enabled = false;
        }

    }

    private void trail()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        cutrope.Raise(other.gameObject);
    }
}

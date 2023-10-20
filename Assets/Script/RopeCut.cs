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
    private Vector3 lastPos;
    void Awake()
    {
        lastPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        camera= Camera.main;
        _collider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            UnityEditor.EditorApplication.isPaused = true;
        }
        if (Input.GetMouseButton(0))
        {
            rb.position = camera.ScreenToWorldPoint(Input.mousePosition);
            Invoke(nameof(trail), 0.05f);
            _collider2D.enabled = true;

            RaycastHit2D hit = Physics2D.Raycast(lastPos, (transform.position - lastPos).normalized,
                (transform.position - lastPos).magnitude, 2176);
            if (hit.collider != null && gameObject.transform.GetChild(0).gameObject.activeSelf)
            {
                cutrope.Raise(hit.transform.gameObject);
            }
        }
        else
        {
            _collider2D.enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        lastPos = transform.position;
    }

    private void trail()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}

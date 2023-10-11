using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCut : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera camera;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera= Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.position = camera.ScreenToWorldPoint(Input.mousePosition);
            Invoke(nameof(trail), 0.05f);
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("Träffa något");
                if (hit.collider.tag == "Rope")
                {
                    Debug.Log("Träffa rep");
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private void trail()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}

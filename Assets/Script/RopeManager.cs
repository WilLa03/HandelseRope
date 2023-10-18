using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool gravity;
    private float GravityScale;
    [SerializeField] private ParticleSystem ParticleSystem;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        GravityScale = rb.gravityScale;
    }

    public void CheckIfDestroy(GameObject target)
    {
        if (target == gameObject)
        {
            PrepDeath();
            RemoveEarlierChains();
        }
    }

    public void RemoveEarlierChains()
    {
        int childCount = gameObject.transform.parent.gameObject.GetComponentsInChildren<HingeJoint2D>().Length-1;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(gameObject.transform.parent.gameObject.transform.GetChild(i).gameObject, 0.5f);
        }
    }
    
    public void ChangeGravity()
    {
        if (!gravity)
        {
            rb.gravityScale = 0;
            gravity = true;
        }
        else
        {
            rb.gravityScale = GravityScale;
            gravity = false;
        }
    }
    void PrepDeath()
    {
        var emission = ParticleSystem.emission;
        emission.enabled = true; 
        ParticleSystem.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<OnBubbleEvent>().enabled = false;
        Destroy(GetComponent<HingeJoint2D>());
        Destroy(GetComponent<Rigidbody2D>());
        Invoke(nameof(DestroyObj),ParticleSystem.main.duration);
    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }
}

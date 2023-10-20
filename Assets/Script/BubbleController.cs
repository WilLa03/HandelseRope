using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField] private OnBubble onBubble;
    [SerializeField] private ParticleSystem ParticleSystem;
    [SerializeField] private AudioSource EnterBubble;
    [SerializeField] private AudioSource DestroyBubble;
    private bool hasBeenEntered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasBeenEntered)
        {
            transform.SetParent(other.transform);
            transform.localPosition = new Vector3(0,0,0);
            gameObject.layer = LayerMask.NameToLayer("Bubble");
            EnterBubble.PlayOneShot(EnterBubble.clip);
            onBubble.Raise();
            hasBeenEntered = true;
        }
        else
        {
            onBubble.Raise();
            PrepDeath();
            DestroyBubble.Play();
        }
        
    }
    void PrepDeath()
    {
        var emission = ParticleSystem.emission;
        emission.enabled = true; 
        ParticleSystem.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(transform.GetChild(0).gameObject);
        Invoke(nameof(DestroyObj),ParticleSystem.main.duration);
    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }
}

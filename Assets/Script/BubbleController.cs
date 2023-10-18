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
    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.SetParent(other.transform);
        transform.localPosition = new Vector3(0,0,0);
        gameObject.layer = LayerMask.NameToLayer("Rope");
        if (EnterBubble.clip != null)
        {
            EnterBubble.PlayOneShot(EnterBubble.clip);
            EnterBubble.clip = null;
        }
        onBubble.Raise();
    }
    public void CheckIfDestroy(GameObject target)
    {
        if (target == gameObject)
        {
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

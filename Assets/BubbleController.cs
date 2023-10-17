using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField] private OnBubble onBubble;
    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.SetParent(other.transform);
        transform.localPosition = new Vector3(0,0,0);
        int Rope = LayerMask.NameToLayer("Rope");
        gameObject.layer = Rope;
        onBubble.Raise();
    }
    public void CheckIfDestroy(GameObject target)
    {
        if (target == gameObject)
        {
            Destroy(gameObject);
        }
    }
}

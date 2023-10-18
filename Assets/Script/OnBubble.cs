using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class OnBubble : ScriptableObject
{
    private List<OnBubbleEvent> _listeners = new List<OnBubbleEvent>();
    public void Raise()
    {
        for (int i = _listeners.Count-1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(OnBubbleEvent listener)
    {
        _listeners.Add(listener);
    }
    public void UnregisterListener(OnBubbleEvent listener)
    {
        _listeners.Remove(listener);
    }
}

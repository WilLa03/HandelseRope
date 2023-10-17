using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class HitBowl : ScriptableObject
{
    private List<HitBowlEvent> _listeners = new List<HitBowlEvent>();

    public void Raise()
    {
        for (int i = _listeners.Count-1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(HitBowlEvent listener)
    {
        _listeners.Add(listener);
    }
    public void UnregisterListener(HitBowlEvent listener)
    {
        _listeners.Remove(listener);
    }
}

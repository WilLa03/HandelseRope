using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class HitBowl : ScriptableObject
{
    private List<HitRopeEvent> _listeners = new List<HitRopeEvent>();

    public void Raise()
    {
        for (int i = _listeners.Count-1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(HitRopeEvent listener)
    {
        _listeners.Add(listener);
    }
    public void UnregisterListener(HitRopeEvent listener)
    {
        _listeners.Remove(listener);
    }
}

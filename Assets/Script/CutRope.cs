using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CutRope : ScriptableObject
{
    private List<CutRopeEvent> _listeners = new List<CutRopeEvent>();

    public void Raise(GameObject target)
    {
        for (int i = _listeners.Count-1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised(target);
        }
    }

    public void RegisterListener(CutRopeEvent listener)
    {
        _listeners.Add(listener);
    }
    public void UnregisterListener(CutRopeEvent listener)
    {
        _listeners.Remove(listener);
    }
}

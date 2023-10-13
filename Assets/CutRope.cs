using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CutRope : ScriptableObject
{
    private List<GameEventListener> _listeners = new List<GameEventListener>();

    public void Raise(GameObject target)
    {
        for (int i = _listeners.Count-1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised(target);
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        _listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListener listener)
    {
        _listeners.Remove(listener);
    }
}

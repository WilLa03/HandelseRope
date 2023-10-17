using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class ScorePoint : ScriptableObject
{
    private List<OnScoreEvent> _listeners = new List<OnScoreEvent>();

    public void Raise()
    {
        for (int i = _listeners.Count-1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(OnScoreEvent listener)
    {
        _listeners.Add(listener);
    }
    public void UnregisterListener(OnScoreEvent listener)
    {
        _listeners.Remove(listener);
    }
}

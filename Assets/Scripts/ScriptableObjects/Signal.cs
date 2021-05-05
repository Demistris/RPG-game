using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
    private List<SignalListener> _listeners = new List<SignalListener>();

    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener signalListener)
    {
        _listeners.Add(signalListener);
    }

    public void DeRegisterListener(SignalListener signalListener)
    {
        _listeners.Remove(signalListener);
    }
}

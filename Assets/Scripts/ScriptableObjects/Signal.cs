using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
    public List<SignalListener> Listeners = new List<SignalListener>();

    public void Raise()
    {
        for (int i = Listeners.Count - 1; i >= 0; i--)
        {
            Listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener signalListener)
    {
        Listeners.Add(signalListener);
    }

    public void DeRegisterListener(SignalListener signalListener)
    {
        Listeners.Remove(signalListener);
    }
}

using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// An event that can be raised without any parameter. 
/// </summary> 
[CreateAssetMenu(fileName = "Void_Channel", menuName = "Scriptable Objects/Events/BuzzerPressEvent")]
public class BuzzerPressEvent : ScriptableObject
{
    private readonly List<BuzzerPressListener> _listeners = new();

    /// <summary> 
    /// Raises the event. This will trigger all the listeners. 
    /// </summary> 
    public void Raise(int buzzerLabel)
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised(buzzerLabel);
    }
    /// <summary> 
    /// Registers a listener to the event. 
    /// </summary> 
    public void Register(BuzzerPressListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    /// <summary> 
    /// Unregisters a listener from the event. 
    /// </summary> 
    public void Unregister(BuzzerPressListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }
}
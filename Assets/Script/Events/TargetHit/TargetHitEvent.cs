using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// An event that can be raised without any parameter. 
/// </summary> 
[CreateAssetMenu(fileName = "Void_Channel", menuName = "Scriptable Objects/Events/TargetEvent")]
public class TargetHitEvent : ScriptableObject
{
    private readonly List<TargetHitListener> _listeners = new();

    /// <summary> 
    /// Raises the event. This will trigger all the listeners. 
    /// </summary> 
    public void Raise(int targetID)
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised(targetID);
    }
    /// <summary> 
    /// Registers a listener to the event. 
    /// </summary> 
    public void Register(TargetHitListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    /// <summary> 
    /// Unregisters a listener from the event. 
    /// </summary> 
    public void Unregister(TargetHitListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }
}
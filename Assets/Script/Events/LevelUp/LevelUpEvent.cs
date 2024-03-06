using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// An event that can be raised without any parameter. 
/// </summary> 
[CreateAssetMenu(fileName = "Void_Channel", menuName = "Scriptable Objects/Events/LevelUpEvent")]
public class LevelUpEvent : ScriptableObject
{
    private readonly List<LevelUpListener> _listeners = new();

    /// <summary> 
    /// Raises the event. This will trigger all the listeners. 
    /// </summary> 
    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised();
    }
    /// <summary> 
    /// Registers a listener to the event. 
    /// </summary> 
    public void Register(LevelUpListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    /// <summary> 
    /// Unregisters a listener from the event. 
    /// </summary> 
    public void Unregister(LevelUpListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }
}
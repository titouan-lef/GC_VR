using UnityEngine;  /// <summary>  /// A listener that listens to a VoidEvent and invokes a UnityEvent when the VoidEvent is raised.  /// </summary>  
public class TargetHitListener : MonoBehaviour
{
    [SerializeField, Tooltip("Event to register with.")]
    private TargetHitEvent _event;
    [SerializeField, Tooltip("Response to invoke when Event is raised.")]
    private UnityEngine.Events.UnityEvent<int> _response;
    private void OnEnable()
    {
        _event.Register(this);
    }
    private void OnDisable()
    {
        _event.Unregister(this);
    }
    /// <summary>      /// Invokes the response of the listener. Usually called by the VoidEvent.      /// </summary>
    public void OnEventRaised(int targetID)
    {
        _response.Invoke(targetID);
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BuzzerPressVisual : MonoBehaviour
{
    [Header("Visual")]
    [SerializeField] private Transform _visualTarget;

    [Header("Button Animation")]
    [SerializeField] private Vector3 _localAxis;                    // Axis where the button will move
    [SerializeField] private float _speedMovement = 5;
    [SerializeField] private float _lenghtPress = 0.1f;

    [Header("Button Event Listener")]
    [SerializeField] private ButtonPressEvent _buzzerPressEvent;

    private Vector3 _initialLocalPos;
    private Vector3 _pressLocalPos;

    private XRBaseInteractable _interactable;

    private bool _isPressing = false;                               // Button is pressed

    void Start()
    {
        _initialLocalPos = _visualTarget.localPosition;
        _pressLocalPos = _initialLocalPos + _localAxis * _lenghtPress;

        _interactable = GetComponentInParent<XRBaseInteractable>();
        _interactable.selectEntered.AddListener(PressButton);
    }

    private void PressButton(BaseInteractionEventArgs hover)
    {
        if (_isPressing)
            return;

        if (hover.interactorObject is XRRayInteractor)
        {
            //_buzzerPressEvent.Raise();
            _isPressing = true;
            StartCoroutine(MoveButton());
        }
    }

    private IEnumerator MoveButton()
    {
        while (_visualTarget.localPosition != _pressLocalPos)
        {
            _visualTarget.localPosition = Vector3.Lerp(_visualTarget.localPosition, _pressLocalPos, Time.deltaTime * _speedMovement);
            yield return null;
        }

        while (_visualTarget.localPosition != _initialLocalPos)
        {
            _visualTarget.localPosition = Vector3.Lerp(_visualTarget.localPosition, _initialLocalPos, Time.deltaTime * _speedMovement);
            yield return null;
        }

        _isPressing = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    [SerializeField] private Transform _visualTarget;
    [SerializeField] private Vector3 _localAxis;        // Axis where the button will move
    [SerializeField] private float _speedMovement = 5;
    [SerializeField] private float _freezeTime = 5;
    [SerializeField] private float _lenghtPress = 0.1f;
    [SerializeField] private InputAction _inputPress;    // Input to press the button

    private Vector3 _initialLocalPos;

    private XRBaseInteractable _interactable;

    private bool _freeze = false;                       // Freeze the button when it's at the selected position
    private bool _isPressing = false;

    void Start()
    {
        _initialLocalPos = _visualTarget.localPosition;

        _interactable = GetComponentInParent<XRBaseInteractable>();
        _interactable.hoverEntered.AddListener(Follow);
        //_interactable.hoverExited.AddListener(Reset);
        _interactable.selectEntered.AddListener(Freeze);

        //_inputPress.Enable();
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRRayInteractor/* && !_isPressing*/)
        {
            //_isPressing = true;
            _freeze = false;
            StartCoroutine(MoveButton());
        }
    }

    public void Reset(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRRayInteractor)
        {
            _isPressing = false;
            _freeze = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRRayInteractor)
        {
            _freeze = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (_freeze)
            return;

        if (_isPressing)
        {
            // Move the button to the pressed position with an animation
            _visualTarget.localPosition = Vector3.Lerp(_visualTarget.localPosition, _initialLocalPos + _localAxis * _lenghtPress, Time.deltaTime * _speedMovement);
        }
        else
        {
            // Come back to initial position with an animation
            _visualTarget.localPosition = Vector3.Lerp(_visualTarget.localPosition, _initialLocalPos, Time.deltaTime * _speedMovement);
        }
    }

    private IEnumerator MoveButton()
    {
        
        _isPressing = true;
        yield return new WaitForSeconds(_freezeTime);
        _isPressing = false;
    }
}



//public class tmp : MonoBehaviour
//{

//    [SerializeField] InputActionReference _input;

//    // Start is called before the first frame update
//    void Start()
//    {
//        _input.action.started += Action_started;

//    }

//    private void OnDestroy()
//    {
//        _input.action.started -= Action_started;
//    }

//    private void Action_started(InputAction.CallbackContext obj)
//    {
//        throw new System.NotImplementedException();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//    }
//}
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    [Header("Visual")]
    [SerializeField] private Transform _visualTarget;
    [SerializeField] private Material _initialMaterial;
    [SerializeField] private Material _selectedMaterial;

    [Header("Button Animation")]
    [SerializeField] private Vector3 _localAxis;                    // Axis where the button will move
    [SerializeField] private float _speedMovement = 5;
    [SerializeField] private float _lenghtPress = 0.1f;

    [Header("Inputs")]
    [SerializeField] private InputActionReference _leftHandPress;
    [SerializeField] private InputActionReference _rightHandPress;

    private bool _leftIsPressing = false;
    private bool _rightIsPressing = false;

    private Vector3 _initialLocalPos;
    private Vector3 _pressLocalPos;

    private XRBaseInteractable _interactable;

    private bool _isPressing = false;                   // Button is pressed
    private bool _isDown = false;                       // Button is down
    private bool _isUp = false;                         // Button is up

    void OnEnable()
    {
        _leftHandPress.action.started += ctx => _leftIsPressing = true;
        _leftHandPress.action.canceled += ctx => _leftIsPressing = false;
        _leftHandPress.action.Enable();

        _rightHandPress.action.started += ctx => _rightIsPressing = true;
        _rightHandPress.action.canceled += ctx => _rightIsPressing = false;
        _rightHandPress.action.Enable();
    }

    void OnDisable()
    {
        _leftHandPress.action.started -= ctx => _leftIsPressing = true;
        _leftHandPress.action.canceled -= ctx => _leftIsPressing = false;
        _leftHandPress.action.Disable();

        _rightHandPress.action.started -= ctx => _rightIsPressing = true;
        _rightHandPress.action.canceled -= ctx => _rightIsPressing = false;
        _rightHandPress.action.Disable();
    }

    void Start()
    {
        _initialLocalPos = _visualTarget.localPosition;
        _pressLocalPos = _initialLocalPos + _localAxis * _lenghtPress;

        _interactable = GetComponentInParent<XRBaseInteractable>();
        _interactable.hoverEntered.AddListener(PressButton);
    }

    public void PressButton(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRRayInteractor)
        {
            // Si rayon Droite/Gauche touche et bouton Droite/Gauche appuyé
            _isPressing = true;
            _isDown = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (_isPressing)
        {
            if (_isDown)// Move the button to the pressed position with an animation
            {
                _visualTarget.localPosition = Vector3.Lerp(_visualTarget.localPosition, _pressLocalPos, Time.deltaTime * _speedMovement);

                if (_visualTarget.localPosition == _pressLocalPos)
                {
                    _isDown = false;
                    _isUp = true;
                }
            }

            if (_isUp)// Come back to initial position with an animation
            {
                _visualTarget.localPosition = Vector3.Lerp(_visualTarget.localPosition, _initialLocalPos, Time.deltaTime * _speedMovement);

                if (_visualTarget.localPosition == _initialLocalPos)
                {
                    _isUp = false;
                    _isPressing = false;
                }
            }
        }
    }

    //StartCoroutine(MoveButton());
    //private IEnumerator MoveButton()
    //{

    //    _isPressing = true;
    //    _isDown = true;
    //    // TO DO : Choice level
    //    yield return new WaitForSeconds(_freezeTime);
    //    _isPressing = false;
    //}
}
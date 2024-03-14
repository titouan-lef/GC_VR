using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPressVisual : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] private GameObject _buttonObject;

    [Header("Visual")]
    [SerializeField] private Transform _visualTarget;
    [SerializeField] private Material _selectedMaterial;
    [SerializeField] private Material _hoveredMaterial;

    [Header("Button Animation")]
    [SerializeField] private Vector3 _localAxis;                    // Axis where the button will move
    [SerializeField] private float _speedMovement = 5;
    [SerializeField] private float _lenghtPress = 0.1f;

    [Header("Button Event Listener")]
    [SerializeField] private ButtonPressEvent _buttonPressEvent;
    
    [Header("Button Label")]
    [SerializeField] private int _buttonPressIndex = 0;

    [Header("Button Sound")]
    [SerializeField] private AudioSource _audioSource;

    private MeshRenderer _meshRenderer;
    private Material _initialMaterial;
    private Material _currentMaterial;

    private Vector3 _initialLocalPos;
    private Vector3 _pressLocalPos;

    private XRBaseInteractable _interactable;

    private bool _isPressing = false;                   // Button is pressed

    private void OnEnable()
    {
        _initialLocalPos = _visualTarget.localPosition;
        _pressLocalPos = _initialLocalPos + _localAxis * _lenghtPress;

        _interactable = GetComponentInParent<XRBaseInteractable>();
        _interactable.selectEntered.AddListener(PressButton);
        _interactable.hoverEntered.AddListener(HoverEnterButton);
        _interactable.hoverExited.AddListener(HoverExitButton);

        _meshRenderer = transform.parent.GetComponent<MeshRenderer>();
        _initialMaterial = _meshRenderer.material;
        _meshRenderer.material = _selectedMaterial;
        _currentMaterial = _selectedMaterial;
    }

    private void PressButton(BaseInteractionEventArgs hover)
    {
        if (_isPressing)
            return;

        if (hover.interactorObject is XRRayInteractor)
        {
            _buttonPressEvent.Raise(_buttonPressIndex);
            _isPressing = true;
            _audioSource.Play();
            _meshRenderer.material = _selectedMaterial;
            _currentMaterial = _selectedMaterial;
            StartCoroutine(MoveButton());
        }
    }

    private void HoverEnterButton(BaseInteractionEventArgs hover)
    {
        _meshRenderer.material = _hoveredMaterial;
    }

    private void HoverExitButton(BaseInteractionEventArgs hover)
    {
        _meshRenderer.material = _currentMaterial;
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

    public void Deselect()
    {
        _meshRenderer.material = _initialMaterial;
        _currentMaterial = _initialMaterial;
    }

    public void Select()
    {
        Debug.Log("Select");
        _meshRenderer.material = _selectedMaterial;
        _currentMaterial = _selectedMaterial;
    }

    public void EnableButton()
    {
        _buttonObject.SetActive(true);
    }

    public bool IsEnabled()
    {
        return _buttonObject.activeInHierarchy;
    }
}
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuSelection : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    private XRBaseInteractable _interactable;

    //void Start()
    //{
    //    _interactable = GetComponent<XRBaseInteractable>();
    //    _interactable.selectEntered.AddListener(PressButton);
    //    _interactable.hoverEntered.AddListener(HoverEnterButton);
    //    _interactable.hoverExited.AddListener(HoverExitButton);
    //}

    //private void PressButton(BaseInteractionEventArgs hover)
    //{

    //    if (hover.interactorObject is XRRayInteractor)
    //    {
    //        _buttonPressEvent.Raise(_buttonPressIndex);
    //        _isPressing = true;
    //        _meshRenderer.material = _selectedMaterial;
    //        _currentMaterial = _selectedMaterial;
    //        StartCoroutine(MoveButton());
    //    }
    //}

    //private void HoverEnterButton(BaseInteractionEventArgs hover)
    //{
    //    _meshRenderer.material = _hoveredMaterial;
    //}

    //private void HoverExitButton(BaseInteractionEventArgs hover)
    //{
    //    _meshRenderer.material = _currentMaterial;
    //}

    //private IEnumerator MoveButton()
    //{
    //    while (_visualTarget.localPosition != _pressLocalPos)
    //    {
    //        _visualTarget.localPosition = Vector3.Lerp(_visualTarget.localPosition, _pressLocalPos, Time.deltaTime * _speedMovement);
    //        yield return null;
    //    }

    //    while (_visualTarget.localPosition != _initialLocalPos)
    //    {
    //        _visualTarget.localPosition = Vector3.Lerp(_visualTarget.localPosition, _initialLocalPos, Time.deltaTime * _speedMovement);
    //        yield return null;
    //    }

    //    _isPressing = false;
    //}

    //public void Deselect()
    //{
    //    Debug.Log("Deselect");
    //    _meshRenderer.material = _initialMaterial;
    //    _currentMaterial = _initialMaterial;
    //}
}
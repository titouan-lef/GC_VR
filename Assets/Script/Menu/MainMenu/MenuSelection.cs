using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuSelection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Color _initialColor;
    [SerializeField] private Color _hoverColor;
    [SerializeField] private string _sceneToLoad;

    private XRBaseInteractable _interactable;

    void Start()
    {
        _interactable = GetComponent<XRBaseInteractable>();
        Debug.Log(_interactable);
        _interactable.selectEntered.AddListener(MenuSelectionned);
        _interactable.hoverEntered.AddListener(HoverEnterButton);
        _interactable.hoverExited.AddListener(HoverExitButton);

        _text.color = _initialColor;
    }

    private void MenuSelectionned(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRRayInteractor)
        {
            SceneManager.LoadScene(_sceneToLoad);
        }
    }

    private void HoverEnterButton(BaseInteractionEventArgs hover)
    {
        Debug.Log("HoverEnterButton");
        _text.color = _hoverColor;
    }

    private void HoverExitButton(BaseInteractionEventArgs hover)
    {
       _text.color = _initialColor;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagazinFeature : MonoBehaviour
{
    [SerializeField] XRSocketInteractor _socket;


    private void Start()
    {
        _socket.GetComponent<XRSocketInteractor>();
        _socket.selectEntered.AddListener(MagazinCharged);
    }

    private void OnDestroy()
    {
        _socket.selectEntered.RemoveListener(MagazinCharged);
    }

    void MagazinCharged(SelectEnterEventArgs e)
    {
        (e.interactableObject as XRGrabInteractable).GetComponent<disabledPhysics>().DisablePhysics();
        (e.interactableObject as XRGrabInteractable).GetComponent<disabledPhysics>().SetParent(transform);
        (e.interactorObject as XRSocketInteractor).transform.parent.GetComponent<ShootWeapon>().ReloadWeapon((e.interactableObject as XRGrabInteractable).gameObject);
    }
}

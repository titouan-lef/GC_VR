using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeshDesactivator : MonoBehaviour
{
    [SerializeField] XRSocketInteractor _socket;


    private void Start()
    {
        _socket.selectEntered.AddListener(OnInteractableEnter);
    }

    private void OnDestroy()
    {
        _socket.selectEntered.RemoveListener(OnInteractableEnter);
    }


    public void DesactivateMesh()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }


    void OnInteractableEnter(SelectEnterEventArgs e)
    {
        (e.interactableObject as XRGrabInteractable).colliders.ForEach(c => c.enabled = false);
    }


}

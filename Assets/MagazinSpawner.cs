using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagazinSpawner : MonoBehaviour
{
    [SerializeField] List<XRRayInteractor> hands;
    [SerializeField] GameObject MagazinPistol;
    [SerializeField] GameObject MagazinNegev;

    [SerializeField] Transform RightPositionMagazine;
    [SerializeField] Transform LeftPositionMagazine;

    void Start()
    {
        foreach (var h in hands)
        {
            h.selectEntered.AddListener(ReloadMagazine);
        }
    }
    public void ReloadMagazine(SelectEnterEventArgs e)
    {
        if ((e.interactableObject as XRGrabInteractable).gameObject.CompareTag("Pistol"))
        {
            Instantiate(MagazinPistol, RightPositionMagazine.position, RightPositionMagazine.rotation, null);
            Instantiate(MagazinPistol, LeftPositionMagazine.position, LeftPositionMagazine.rotation, null);
        }
        if ((e.interactableObject as XRGrabInteractable).gameObject.CompareTag("Negev"))
        {
            Instantiate(MagazinNegev, RightPositionMagazine.position, RightPositionMagazine.rotation, null);
            Instantiate(MagazinNegev, LeftPositionMagazine.position, LeftPositionMagazine.rotation, null);
        }
    }
}
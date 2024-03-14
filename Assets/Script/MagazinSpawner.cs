using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class MagazinSpawner : MonoBehaviour
{
    [SerializeField] XRRayInteractor Righthands;
    [SerializeField] XRRayInteractor Lefthands;

    [SerializeField] GameObject MagazinPistol;
    [SerializeField] GameObject MagazinNegev;
    [SerializeField] GameObject MagazinM4;

    [SerializeField] Transform RightPositionMagazine;
    [SerializeField] Transform LeftPositionMagazine;

    private List<GameObject> _magazins = new List<GameObject>();
    void Start()
    {
        Righthands.selectEntered.AddListener(RightReloadMagazine);
        Lefthands.selectEntered.AddListener(LeftReloadMagazine);
        Righthands.selectExited.AddListener(test);
        Lefthands.selectExited.AddListener(test);
    }
    public void RightReloadMagazine(SelectEnterEventArgs e)
    {
        if(e.interactableObject as XRGrabInteractable != null)
        {
            SelectMagazin(RightPositionMagazine.position, LeftPositionMagazine.position, (e.interactableObject as XRGrabInteractable).gameObject.tag, (e.interactableObject as XRGrabInteractable).gameObject);
        }
    }
    public void LeftReloadMagazine(SelectEnterEventArgs e)
    {
        if (e.interactableObject as XRGrabInteractable != null)
        {
            SelectMagazin(LeftPositionMagazine.position, RightPositionMagazine.position, (e.interactableObject as XRGrabInteractable).gameObject.tag, (e.interactableObject as XRGrabInteractable).gameObject);
        }
    }

    private void SelectMagazin(Vector3 currentPosition, Vector3 oppositePosition, string tag, GameObject interractable)
    {
        if (tag == "Pistol")
        {
            foreach(GameObject go in _magazins)
            {
                Destroy(go);
            }
            _magazins.Add(Instantiate(MagazinPistol, oppositePosition, transform.rotation, null));
        }
        if (tag == "Negev")
        {
            foreach(GameObject go in _magazins)
            {
                Destroy(go);
            }
            _magazins.Add(Instantiate(MagazinNegev, oppositePosition, transform.rotation, null));
        }
        if (tag == "M4")
        {
            foreach (GameObject go in _magazins)
            {
                Destroy(go);
            }
            _magazins.Add(Instantiate(MagazinM4, oppositePosition, transform.rotation, null));
        }
        if (tag == "PistolMagazin")
        {
            _magazins.Remove(interractable);
            _magazins.Add(Instantiate(MagazinPistol, currentPosition, transform.rotation, null));
        }
        if (tag == "NegevMagazin")
        {
            _magazins.Remove(interractable);
            _magazins.Add(Instantiate(MagazinNegev, currentPosition, transform.rotation, null));
        }
        if (tag == "M4Magazin")
        {
            _magazins.Remove(interractable);
            _magazins.Add(Instantiate(MagazinM4, currentPosition, transform.rotation, null));
        }
    }
    private void test(SelectExitEventArgs e)
    {
        if ((e.interactableObject as XRGrabInteractable != null) && ((e.interactableObject as XRGrabInteractable).gameObject.CompareTag("PistolMagazin") || (e.interactableObject as XRGrabInteractable).gameObject.CompareTag("NegevMagazine") || (e.interactableObject as XRGrabInteractable).gameObject.CompareTag("M4Magazin")))
        {
            Debug.Log((e.interactableObject as XRGrabInteractable).gameObject.GetComponent<Rigidbody>().constraints);
            (e.interactableObject as XRGrabInteractable).gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        }
    }
}
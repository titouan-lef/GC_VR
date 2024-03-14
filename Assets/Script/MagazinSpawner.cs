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
        //Lefthands.selectExited.AddListener(test);
    }
    public void RightReloadMagazine(SelectEnterEventArgs e)
    {
        if((e.interactableObject as XRGrabInteractable).gameObject.tag != null)
        {
            SelectMagazin(RightPositionMagazine.position, LeftPositionMagazine.position, (e.interactableObject as XRGrabInteractable).gameObject.tag, e);
        }
    }
    public void LeftReloadMagazine(SelectEnterEventArgs e)
    {
        if ((e.interactableObject as XRGrabInteractable).gameObject.tag != null)
        {
            SelectMagazin(LeftPositionMagazine.position, RightPositionMagazine.position, (e.interactableObject as XRGrabInteractable).gameObject.tag, e);
        }
    }

    private void SelectMagazin(Vector3 currentPosition, Vector3 oppositePosition, string tag, SelectEnterEventArgs e)
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
            _magazins.Add(Instantiate(MagazinPistol, currentPosition, transform.rotation, null));
        }
        if (tag == "NegevMagazin")
        {
            _magazins.Add(Instantiate(MagazinNegev, currentPosition, transform.rotation, null));
        }
        if (tag == "M4Magazin")
        {
            _magazins.Add(Instantiate(MagazinM4, currentPosition, transform.rotation, null));
        }
    }
    /*private void test(SelectExitEventArgs e)
    {
        if (tag == "PistolMagazin")
        {
            (e.interactableObject as XRGrabInteractable).gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }*/
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponUnlock : MonoBehaviour
{
    [SerializeField]
    private int _numWeaponParts;

    private int _currentPartNum = 0;

    [SerializeField]
    private GameObject _weapon;

    [SerializeField]
    private List<GameObject> parts = new List<GameObject>();

    public void AddWeaponPart(SelectEnterEventArgs e)
    {
        parts.Add((e.interactableObject as XRGrabInteractable).gameObject);
        _currentPartNum++;
        Debug.Log("partAdded");
        if (_currentPartNum == _numWeaponParts)
        {
            Instantiate(_weapon, transform.position, transform.rotation);
            for (int i = 0; i < _numWeaponParts; i++)
            {
                GameObject part = parts[parts.Count -1];
                parts.Remove(part);
                Destroy(part);
            }
            Destroy(this.gameObject);
        }
    }
}

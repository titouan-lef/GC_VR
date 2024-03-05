using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int _associatedKey = 0;

    [SerializeField]
    private Event _event; 
    // Start is called before the first frame update
    void Start()
    {
        _associatedKey += 256;
    }

    // Update is called once per frame
    void Update()
    {
        // Remove after tests ------
        if (Input.GetKeyDown((KeyCode)_associatedKey))
        {
            TargetHit();
        }
        // End of Removal ----------
    }

    private void OnTriggerEnter(Collider other)
    {
        TargetHit();
    }

    public void TargetHit()
    {
        _event.Raise(_associatedKey - 256);
    }

    public void ToggleLight()
    {
        Light simonLight = GetComponentInChildren<Light>();
        simonLight.enabled = !simonLight.enabled;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    public int associatedKey = 0;

    private int _correctedKey;

    [SerializeField]
    private Event _event; 
    // Start is called before the first frame update
    void Start()
    {
        _correctedKey = associatedKey + 256;
    }

    // Update is called once per frame
    void Update()
    {
        // Remove after tests ------
        if (Input.GetKeyDown((KeyCode)_correctedKey))
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
        _event.Raise(associatedKey);
    }

    public void ToggleLight()
    {
        Light simonLight = GetComponentInChildren<Light>();
        simonLight.enabled = !simonLight.enabled;
    }
}

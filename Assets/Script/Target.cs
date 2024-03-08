using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    public int associatedKey = 0;

    private int _correctedKey;

    private Light _light;

    [SerializeField]
    private TargetHitEvent _targetHitEvent;
    // Start is called before the first frame update
    void Start()
    {
        _correctedKey = associatedKey + 256;
        _light = GetComponentInChildren<Light>();
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

    private void OnCollisionEnter(Collision collision)
    {
        TargetHit();
    }

    public void TargetHit()
    {
        _targetHitEvent.Raise(associatedKey);
    }

    public void SwitchLightOn()
    {
        _light.enabled = true;
    }

    public void SwitchLightOff()
    {
        _light.enabled = false;
    }

    public bool IsLightOn()
    {
        return _light.enabled;
    }
}

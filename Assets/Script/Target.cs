using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    public int associatedKey = 0;

    [SerializeField]
    public int targetType = 0;

    private int _correctedKey;

    private Light _light;

    [SerializeField]
    private AudioClip _audioClip;

    [SerializeField]
    private TargetHitEvent _targetHitEvent;
    // Start is called before the first frame update
    void Start()
    {
        _correctedKey = associatedKey + 256;
        _light = GetComponentInChildren<Light>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        TargetHit();
    }

    public void TargetHit()
    {
        AudioSource.PlayClipAtPoint(_audioClip, transform.position);
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

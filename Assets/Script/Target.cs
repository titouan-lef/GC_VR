using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Remove after tests ------
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TargetHit();
        }
        // End of Removal ----------
    }

    private void OnTriggerEnter(Collider other)
    {
        TargetHit();
    }

    private void TargetHit()
    {
        Debug.Log("Touché");
    }

    public void ToggleLight()
    {
        Light simonLight = GetComponentInChildren<Light>();
        simonLight.enabled = !simonLight.enabled;
    }
}

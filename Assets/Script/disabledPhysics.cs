using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class disabledPhysics : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    Collider coll;

    public void DisablePhysics()
    {
        rb.useGravity = false;
        coll.enabled = false;
    }
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
}
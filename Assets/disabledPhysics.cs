using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
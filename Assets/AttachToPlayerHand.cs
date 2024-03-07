using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlayerHand : MonoBehaviour
{
    public Transform RightHand;

    public void AttachToHand()
    {
        transform.position = RightHand.transform.position;
        transform.parent = RightHand;
    }
}

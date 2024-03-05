using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    float m_Lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, m_Lifetime);
    }
}
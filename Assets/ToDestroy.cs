using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDestroy : MonoBehaviour
{
    [SerializeField]
    float m_Timer;
    void Start()
    {
        Destroy(gameObject, m_Timer);
    }
}

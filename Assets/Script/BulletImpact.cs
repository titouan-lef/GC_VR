using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class BulletImpact : MonoBehaviour
{
    [SerializeField]
    float m_Lifetime = 5f;
    [SerializeField] GameObject m_VFX;

    private void Start()
    {
        Destroy(gameObject, m_Lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(m_VFX, collision.GetContact(0).point, transform.rotation);
        Destroy(gameObject);

    }
     
}
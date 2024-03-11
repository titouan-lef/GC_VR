using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BulletImpact : MonoBehaviour
{
    [SerializeField]
    float m_Lifetime = .5f;
    [SerializeField] GameObject m_VFX;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(m_VFX, collision.GetContact(0).point, transform.rotation);
        Destroy(gameObject);
    }
}
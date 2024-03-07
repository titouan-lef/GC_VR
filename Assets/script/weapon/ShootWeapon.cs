using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject m_BulletPrefab = null;

    [SerializeField]
    GameObject m_BulletCasePrefab = null;

    [SerializeField]
    Transform m_LaunchBulletPoint = null;

    [SerializeField]
    Transform m_LaunchBulletCasePoint = null;

    [SerializeField]
    float m_LaunchSpeed = 100f;

    [SerializeField]
    float m_EjectSpeed = 25f;

    [SerializeField]
    GameObject slide;

    [SerializeField]
    AudioSource panpanSound;

    public void Fire(ActivateEventArgs arg)
    {
        GameObject NewBullet = Instantiate(m_BulletPrefab, m_LaunchBulletPoint.position, m_LaunchBulletPoint.rotation, null);
        GameObject NewBulletCase = Instantiate(m_BulletCasePrefab, m_LaunchBulletCasePoint.position, m_BulletCasePrefab.transform.rotation, null);

        if (NewBullet.TryGetComponent(out Rigidbody bulletrigidBody))
            ApplyForce(bulletrigidBody, -m_LaunchSpeed);
        if (NewBulletCase.TryGetComponent(out Rigidbody bulletCaserigidBody))
            ApplyForce(bulletCaserigidBody, m_EjectSpeed);
    }

    void ApplyForce(Rigidbody rigidBody, float speed)
    {
        Debug.Log(rigidBody);
        Vector3 force = m_LaunchBulletPoint.forward * speed;
        rigidBody.AddForce(force);
    }
}

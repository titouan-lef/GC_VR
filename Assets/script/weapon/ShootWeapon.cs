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
    float m_LaunchSpeed = 500f;

    [SerializeField]
    float m_EjectSpeed = 25f;

    [SerializeField]
    Animator anim;

    [SerializeField]
    AudioSource fireSound;

    [SerializeField]
    float m_FireRate = 0.5f;

    private float lastShot = 0.0f;

    private bool isCharged = false;

    public void Fire()
    {
        if (isCharged && Time.time > m_FireRate + lastShot)
        {
            GameObject NewBullet = Instantiate(m_BulletPrefab, m_LaunchBulletPoint.position, m_LaunchBulletPoint.rotation, null);
            GameObject NewBulletCase = Instantiate(m_BulletCasePrefab, m_LaunchBulletCasePoint.position, m_BulletCasePrefab.transform.rotation, null);

            if (NewBullet.TryGetComponent(out Rigidbody bulletrigidBody))
                ApplyForce(bulletrigidBody,  m_LaunchSpeed);
            if (NewBulletCase.TryGetComponent(out Rigidbody bulletCaserigidBody))
                ApplyForce(bulletCaserigidBody, m_EjectSpeed);

            anim.SetTrigger("Shoot");
            fireSound.Play();
            lastShot = Time.time;
        }

    }

    void ApplyForce(Rigidbody rigidBody, float speed)
    {
        rigidBody.AddForce(rigidBody.transform.forward * speed);
    }

    public void ReloadWeapon()
    {
        isCharged = true;
    }
}

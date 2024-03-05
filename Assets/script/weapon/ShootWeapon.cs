using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            EjectWeaponTroll();
        }
    }

    public void Fire()
    {
        GameObject NewBullet = Instantiate(m_BulletPrefab, m_LaunchBulletPoint.position, m_LaunchBulletPoint.rotation, null);
        GameObject NewBulletCase = Instantiate(m_BulletCasePrefab, m_LaunchBulletCasePoint.position, m_BulletCasePrefab.transform.rotation, null);
        ShootAnim();
        PlayShootSound();
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
    private void ShootAnim()
    {
        slide.transform.position = new Vector3(slide.transform.position.x, slide.transform.position.y, slide.transform.position.z + 0.044f);
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        slide.transform.position = new Vector3(slide.transform.position.x, slide.transform.position.y, slide.transform.position.z - 0.044f);

    }

    private void PlayShootSound()
    {
        panpanSound.Play(0);
    }
    private void EjectWeaponTroll()
    {
        if (TryGetComponent(out Rigidbody rb))
        {
            ApplyForce(rb, -m_LaunchSpeed);
        }

    }
}

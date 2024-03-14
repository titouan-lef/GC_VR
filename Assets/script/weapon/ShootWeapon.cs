using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
    AudioSource weaponSource;

    [SerializeField]
    AudioClip fireSound;

    [SerializeField]
    AudioClip noAmmoSound;

    [SerializeField]
    AudioClip reloadSound;

    [SerializeField]
    float m_FireRate = 0.5f;

    [SerializeField]
    int nbBullet = 12;

    private int nbCurrentBullet;

    bool isTriggerPressed = false;

    bool canShoot = true;

    private bool isCharged = false;

    private GameObject currentMagazine;

    [SerializeField]
    TextMeshProUGUI nbBulletUI;

    public void Fire()
    {
        if (isCharged && canShoot)
        {
            GameObject NewBullet = Instantiate(m_BulletPrefab, m_LaunchBulletPoint.position, m_LaunchBulletPoint.rotation, null);
            GameObject NewBulletCase = Instantiate(m_BulletCasePrefab, m_LaunchBulletCasePoint.position, m_BulletCasePrefab.transform.rotation, null);

            if (NewBullet.TryGetComponent(out Rigidbody bulletrigidBody))
                ApplyForce(bulletrigidBody, m_LaunchSpeed);
            if (NewBulletCase.TryGetComponent(out Rigidbody bulletCaserigidBody))
                ApplyForce(bulletCaserigidBody, m_EjectSpeed);

            anim.SetTrigger("Shoot");
            weaponSource.clip = fireSound;
            weaponSource.Play();
            canShoot = false;
            StartCoroutine(waitForNextShot());
            nbCurrentBullet--;
            if (nbCurrentBullet <= 0)
            {
                RunOutOfAmo();
            }
            UpdateUI();
        }
        if (!isCharged)
        {
            weaponSource.clip = noAmmoSound;
            weaponSource.Play();
        }
    }

    public void StartFire()
    {
        isTriggerPressed = true;
        Fire();
    }
    public void StopFire()
    {
        isTriggerPressed = false;
    }

    void ApplyForce(Rigidbody rigidBody, float speed)
    {
        rigidBody.AddForce(rigidBody.transform.forward * speed);
    }

    public void ReloadWeapon(GameObject magazine)
    {
        weaponSource.clip = reloadSound;
        weaponSource.Play();
        isCharged = true;
        currentMagazine = magazine;
        nbCurrentBullet = nbBullet;
    }

    public void RunOutOfAmo()
    {
        isCharged = false;
        currentMagazine.GetComponent<Rigidbody>().useGravity = true;
        currentMagazine.GetComponent<XRGrabInteractable>().enabled = false;
        StartCoroutine(DestroyMagazine(currentMagazine));
    }

    private void UpdateUI()
    {
        nbBulletUI.text = nbCurrentBullet.ToString();
    }

    private IEnumerator waitForNextShot()
    {
        yield return new WaitForSeconds(m_FireRate);
        canShoot = true;
        if (isTriggerPressed)
        {
            Fire();
        }
    }

    private IEnumerator DestroyMagazine(GameObject magazine)
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(magazine);
    }
}

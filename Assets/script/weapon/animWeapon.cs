using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class animWeapon : MonoBehaviour
{
    public GameObject slide;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ShootAnim();
        }
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
}
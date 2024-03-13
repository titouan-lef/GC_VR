using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardPoint : MonoBehaviour
{  
    [SerializeField]
    private List<GameObject> m_WeaponParts = new List<GameObject>();

    private int m_Index = 0;

    public void SpawnReward()
    {
        var go = Instantiate(m_WeaponParts[m_Index], transform);
        go.transform.localPosition = Vector3.zero;
        m_Index++;
    }
}

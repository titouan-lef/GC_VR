using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSetup", menuName = "Scriptable Objects/LevelSetup")]
public class LevelSetup : ScriptableObject
{
    List<Transform> targetPoses;

    public List<Transform> GetTagetPoses()
    {
        return targetPoses;
    }

    public void SetTargetPoses()
    {
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in allTargets)
        {
            targetPoses.Add(target.transform);
        }
    }
}

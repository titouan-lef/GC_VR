using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSetup_X", menuName = "Scriptable Objects/Level Setup")]
public class LevelSetup : ScriptableObject
{
    public List<Vector3> targetsPoses;
    public List<Quaternion> targetsRotation;
    public List<int> targetsType;

    public void SetTargets(GameObject allTargets)
    {
        targetsPoses = new List<Vector3>();
        targetsRotation = new List<Quaternion>();
        targetsType = new List<int>();
        for (int i = 0; i < allTargets.transform.childCount; i++)
        {
            targetsPoses.Add(allTargets.transform.GetChild(i).gameObject.transform.position);
            targetsRotation.Add(allTargets.transform.GetChild(i).gameObject.transform.rotation);
            targetsType.Add(allTargets.transform.GetChild(i).GetComponent<Target>().targetType);
        }
    }
}

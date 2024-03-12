using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit.UI;
using UnityEditor.VersionControl;
using Unity.XR.CoreUtils;
using Unity.Properties;

[CreateAssetMenu(fileName = "LevelSetup_X", menuName = "Scriptable Objects/Level Setup")]
public class LevelSetup : ScriptableObject
{
    public List<Vector3> targetsPoses;
    public List<Quaternion> targetsRotation;

    public void SetTargets(GameObject allTargets)
    {
        targetsPoses = new List<Vector3>();
        targetsRotation = new List<Quaternion>();
        for (int i = 0; i < allTargets.transform.childCount; i++)
        {
            targetsPoses.Add(allTargets.transform.GetChild(i).gameObject.transform.position);
            targetsRotation.Add(allTargets.transform.GetChild(i).gameObject.transform.rotation);
        }
    }
}

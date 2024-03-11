using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(MakeLevelSetup))]
public class GenerateLevelSetup : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate Level Setup"))
        {
            MakeLevelSetup.CreateAsset();
        }
    }
}

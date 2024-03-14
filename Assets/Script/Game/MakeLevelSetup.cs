using Unity.XR.CoreUtils;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class MakeLevelSetup : MonoBehaviour
{
    private static LevelSetup _asset;

    [SerializeField]
    private GameObject targetParent;

    [MenuItem("Assets/ScriptableObjects/LevelSetup")]
    public static void CreateAsset()
    {
        var @this = FindObjectOfType<MakeLevelSetup>();

        _asset = ScriptableObject.CreateInstance<LevelSetup>();
        _asset.SetTargets(@this.targetParent);

        AssetDatabase.CreateAsset(_asset, "Assets/ScriptableObjects/LevelSetup/LevelSetup_X.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = _asset;
    }
}
#endif
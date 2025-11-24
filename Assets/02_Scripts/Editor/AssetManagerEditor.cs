using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AssetManager))]
public class AssetManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        var assetManager = (AssetManager)target;
        assetManager.assetName = EditorGUILayout.TextField("Asset Name", assetManager.assetName);

        if (GUILayout.Button("전사 로드"))
        {
            assetManager.LoadAsset();
        }
    }
}

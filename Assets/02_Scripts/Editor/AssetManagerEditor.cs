using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AssetManager))]
public class AssetManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        var assetManager = (AssetManager)target;

        if (GUILayout.Button("전사 로드"))
        {
            assetManager.LoadAssetAsync(assetManager.assetName);
        }
        
        if (GUILayout.Button("전사 해제"))
        {
            assetManager.UnloadAssetAsync();
        }
    }
}

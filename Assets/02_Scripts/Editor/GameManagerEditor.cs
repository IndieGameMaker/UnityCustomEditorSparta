using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var gameManager = (GameManager)target;

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("적 생성"))
        {
            
        }
        
        if (GUILayout.Button("적 제거"))
        {
            
        }
        EditorGUILayout.EndHorizontal();
    }
}

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var gameManager = (GameManager)target;

        base.OnInspectorGUI();
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("적 생성"))
        {
            gameManager.SpawnEnemy();
        }
        
        if (GUILayout.Button("적 제거"))
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                DestroyImmediate(enemy);
            }
        }
        EditorGUILayout.EndHorizontal();
    }
}

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerStats))]
public class PlayerStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // 대상 클래스를 추출
        var playerStats = (PlayerStats) target; // target as PlayerStats;
        
        // MonoBehaviour 스크립트 필드 
        
        EditorGUILayout.HelpBox("주인공 캐릭터 스텟", MessageType.Info);
        
        // 일반 입력 필드
        playerStats.hp = EditorGUILayout.IntField("HP", playerStats.hp);
        playerStats.mp = EditorGUILayout.IntSlider("MP", playerStats.mp, 0, 100); // [Range(0, 100)]
    }
}

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
        EditorGUILayout.ObjectField("스크립트", MonoScript.FromMonoBehaviour((PlayerStats) target), typeof(PlayerStats), false);
        EditorGUILayout.HelpBox("주인공 캐릭터 스텟", MessageType.Info);
        
        // 일반 입력 필드
        playerStats.hp = EditorGUILayout.IntField("HP", playerStats.hp);
        playerStats.mp = EditorGUILayout.IntSlider("MP", playerStats.mp, 0, 100); // [Range(0, 100)]
        
        // 무적 모드 버튼
        if (GUILayout.Button(playerStats.isGodMode ? "무적모드" : "일반모드"))
        {
            playerStats.isGodMode = !playerStats.isGodMode;
        }
        
        // 데이터 초기화 버튼
        if (GUILayout.Button("데이터 초기화"))
        {
            playerStats.InitPlayerData();
        }
    }
}

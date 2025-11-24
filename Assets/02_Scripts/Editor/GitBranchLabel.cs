using UnityEditor;
using UnityEngine;
using System.IO;

[InitializeOnLoad]
public static class GitBranchLabel
{
    static string branchName = "unknown";
    static string lastHeadContent = "";
    static double lastCheckTime = 0;
    const double checkInterval = 1.0; // 1초마다 체크

    static GitBranchLabel()
    {
        UpdateBranchName();
        SceneView.duringSceneGui += OnSceneGUI;
        EditorApplication.update += CheckBranchChange;
    }

    static void CheckBranchChange()
    {
        // 일정 시간마다만 체크
        if (EditorApplication.timeSinceStartup - lastCheckTime < checkInterval)
            return;

        lastCheckTime = EditorApplication.timeSinceStartup;

        try
        {
            string gitHeadPath = Path.Combine(Directory.GetCurrentDirectory(), ".git", "HEAD");
            if (File.Exists(gitHeadPath))
            {
                string headContent = File.ReadAllText(gitHeadPath).Trim();

                // HEAD 내용이 변경되었을 때만 업데이트
                if (headContent != lastHeadContent)
                {
                    lastHeadContent = headContent;
                    UpdateBranchName();
                    SceneView.RepaintAll();
                }
            }
        }
        catch
        {
            // 에러 무시
        }
    }

    static void UpdateBranchName()
    {
        try
        {
            string gitHeadPath = Path.Combine(Directory.GetCurrentDirectory(), ".git", "HEAD");
            if (File.Exists(gitHeadPath))
            {
                string headContent = File.ReadAllText(gitHeadPath).Trim();
                if (headContent.StartsWith("ref:"))
                {
                    branchName = headContent.Split('/')[^1]; // 가장 마지막 부분 (브랜치명)
                }
                else
                {
                    branchName = "detached HEAD";
                }
            }
            else
            {
                branchName = "no .git";
            }
        }
        catch
        {
            branchName = "error";
        }
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        Handles.BeginGUI();

        GUIStyle style = new GUIStyle(EditorStyles.label);
        style.fontSize = 14;
        style.normal.textColor = Color.white;
        style.fontStyle = FontStyle.Bold;

        Rect rect = new Rect(50, 10, 300, 25);
        GUI.Label(rect, $"Git Branch: {branchName}", style);

        Handles.EndGUI();
    }
}
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Valve.VR;

[InitializeOnLoad]
public static class TogglePauseMode
{
    private static SteamVR_Action_Boolean pauseAction;
    private static bool isPaused = false;

    static TogglePauseMode()
    {
        // SteamVRのアクションが正しくロードされているかチェック
        pauseAction = SteamVR_Input.GetBooleanAction("TogglePauseMode");

        if (pauseAction == null)
        {
            Debug.LogError("SteamVRアクション 'TogglePauseMode' が見つかりません！ SteamVR Inputウィンドウでアクションを作成し、再生成してください。");
            return;
        }

        EditorApplication.update += CheckInput;
    }

    private static bool previousState = false;

    private static void CheckInput()
    {
        // 現在のボタン状態を取得
        bool currentState = pauseAction.state;

        // ボタンが押された瞬間を検出
        if (currentState && !previousState)
        {
            EditorApplication.isPaused = !EditorApplication.isPaused;
            Debug.Log(EditorApplication.isPaused ? "ゲームを一時停止しました" : "ゲームを再開しました");
        }

        // 状態を更新
        previousState = currentState;
    }

}
#endif
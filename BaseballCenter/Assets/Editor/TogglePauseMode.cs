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
        // SteamVR�̃A�N�V���������������[�h����Ă��邩�`�F�b�N
        pauseAction = SteamVR_Input.GetBooleanAction("TogglePauseMode");

        if (pauseAction == null)
        {
            Debug.LogError("SteamVR�A�N�V���� 'TogglePauseMode' ��������܂���I SteamVR Input�E�B���h�E�ŃA�N�V�������쐬���A�Đ������Ă��������B");
            return;
        }

        EditorApplication.update += CheckInput;
    }

    private static bool previousState = false;

    private static void CheckInput()
    {
        // ���݂̃{�^����Ԃ��擾
        bool currentState = pauseAction.state;

        // �{�^���������ꂽ�u�Ԃ����o
        if (currentState && !previousState)
        {
            EditorApplication.isPaused = !EditorApplication.isPaused;
            Debug.Log(EditorApplication.isPaused ? "�Q�[�����ꎞ��~���܂���" : "�Q�[�����ĊJ���܂���");
        }

        // ��Ԃ��X�V
        previousState = currentState;
    }

}
#endif
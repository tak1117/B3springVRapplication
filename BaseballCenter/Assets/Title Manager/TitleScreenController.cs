using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class TitleScreenController : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.LeftHand; // ����̃R���g���[���[
    public SteamVR_Behaviour_Pose controllerPose;

    public Button[] buttons; // �V�[���ɔz�u����Ă���{�^��
    private int currentButtonIndex = 0;  // ���ݑI�𒆂̃{�^���̃C���f�b�N�X

    private Vector2 joystickInput;
    private float lastMoveTime = 0f;  // �Ō�Ƀ{�^�����ړ���������
    private float moveCooldown = 0.3f; // �N�[���_�E�����ԁi0.3�b�j

    void Update()
    {
        // �W���C�X�e�B�b�N�̓����������擾
        joystickInput = SteamVR_Actions.default_Move.GetAxis(inputSource);

        // �W���C�X�e�B�b�N�̓����iX���j�Ń{�^���I�����ړ�
        if (Time.time - lastMoveTime > moveCooldown)
        {
            if (joystickInput.x > 0.5f) // ������
            {
                currentButtonIndex = Mathf.Min(currentButtonIndex + 1, buttons.Length - 1); // ���̃{�^����
                lastMoveTime = Time.time;
                Debug.Log("Button Index Moved Right: " + currentButtonIndex);
                UpdateButtonHighlight();
            }
            else if (joystickInput.x < -0.5f) // ������
            {
                currentButtonIndex = Mathf.Max(currentButtonIndex - 1, 0); // �O�̃{�^����
                lastMoveTime = Time.time;
                Debug.Log("Button Index Moved Left: " + currentButtonIndex);
                UpdateButtonHighlight();
            }
        }

        // A�{�^���iDecide�j�������ꂽ��A�I�����ꂽ�{�^���̃V�[�������[�h
        if (SteamVR_Actions.default_Decide.stateDown)
        {
            Debug.Log("A�{�^����������܂����B�V�[�������[�h���܂�: " + GetCurrentSceneName());
            LoadScene();
        }

        // �{�^���I����Ԃ̍X�V
        UpdateButtonHighlight();
    }

    private void LoadScene()
    {
        string sceneName = GetCurrentSceneName();
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log("Loading Scene: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("�V�[�������ݒ肳��Ă��܂���I");
        }
    }

    private void UpdateButtonHighlight()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Image buttonImage = buttons[i].GetComponent<Image>();

            if (buttonImage != null)
            {
                if (i == currentButtonIndex)
                {
                    buttonImage.color = new Color(1f, 0.647f, 0f); // �I�����W�F
                    Debug.Log("Highlighted Button: " + buttons[i].name);
                }
                else
                {
                    buttonImage.color = Color.white;
                }
            }
            else
            {
                Debug.LogWarning("Button " + buttons[i].name + " does not have an Image component.");
            }
        }

        Canvas.ForceUpdateCanvases();
    }

    public string GetCurrentSceneName()
    {
        if (buttons.Length > 0 && currentButtonIndex >= 0 && currentButtonIndex < buttons.Length)
        {
            return buttons[currentButtonIndex].name; // �I�𒆂̃{�^�����i�V�[�����j��Ԃ�
        }
        return "";
    }
}

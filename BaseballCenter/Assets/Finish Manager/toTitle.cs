using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class toTitle : MonoBehaviour
{
    // �J�ڐ�̃V�[�������C���X�y�N�^�[�Őݒ�ł���悤�ɂ���
    public string sceneToLoad = "Title"; // �f�t�H���g��"Title"��ݒ�

    // SteamVR Input�̃{�^���ݒ�i�����ł�A�{�^���ɑΉ�����PrimaryButton�j
    public SteamVR_Action_Boolean primaryButtonAction;

    void Update()
    {
        // A�{�^���������ꂽ��
        if (primaryButtonAction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            // �ݒ肳�ꂽ�V�[�����ɑJ��
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

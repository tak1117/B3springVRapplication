using UnityEngine;
using UnityEngine.UI; // Text���g���ꍇ
using UnityEngine.SceneManagement; // �V�[���J�ڂ̂���
using TMPro; // TextMeshPro�p�̖��O���

public class ShowFinish : MonoBehaviour
{
    public TextMesh finishText; // Text�R���|�[�l���g���C���X�y�N�^�[�ŃA�^�b�`
    public float displayTime = 108.491f; // ������\�����鎞��
    public string sceneToLoad = "FinishScene"; // �ړ��������V�[����

    void Start()
    {
        Invoke("ShowFinishText", displayTime); // 108.491�b��ɕ�����\��
        Invoke("LoadFinishScene", displayTime + 5f); // 113.491�b���Finish�V�[���ɑJ��
    }

    void ShowFinishText()
    {
        finishText.text = "Finish!"; // Finish!�̕�����\��
    }

    void LoadFinishScene()
    {
        SceneManager.LoadScene(sceneToLoad); // Finish�V�[���֑J��
    }
}

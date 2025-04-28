using UnityEngine;

public class DisplayPlayBall : MonoBehaviour
{
    public TextMesh textObject; // TextMeshPro�̏ꍇ
    // public Text textObject; // �ʏ��Text�̏ꍇ
    private float displayTime = 5f; // �\�����鎞�ԁi�b�j
    private float delayTime = 1f; // �\���܂ł̒x�����ԁi�b�j

    void Start()
    {
        // ������Ԃł͔�\��
        textObject.gameObject.SetActive(false);

        // �Q�[���J�n1�b��ɕ�����\��
        Invoke("ShowText", delayTime);
    }

    void ShowText()
    {
        textObject.gameObject.SetActive(true); // �e�L�X�g��\��
        Invoke("HideText", displayTime); // 2�b��Ƀe�L�X�g���\���ɂ���
    }

    void HideText()
    {
        textObject.gameObject.SetActive(false); // �e�L�X�g���\��
    }
}

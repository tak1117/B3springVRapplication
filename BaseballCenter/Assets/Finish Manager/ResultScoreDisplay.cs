using UnityEngine;

public class ResultScoreDisplay : MonoBehaviour
{
    private TextMesh resultScoreText3D;

    private void Start()
    {
        // ���U���g�p�̃e�L�X�g�I�u�W�F�N�g���쐬
        GameObject textObj = new GameObject("ResultScoreText3D");
        textObj.transform.position = new Vector3(0, 1, -16);  // �ʒu�𒲐�

        // ��]�ݒ�
        textObj.transform.rotation = Quaternion.Euler(90, 0, 0); 

        // TextMesh��ǉ�
        resultScoreText3D = textObj.AddComponent<TextMesh>();
        resultScoreText3D.fontSize = 100;
        resultScoreText3D.color = Color.yellow;

        // �A���J�[�ݒ�i���������j
        resultScoreText3D.anchor = TextAnchor.UpperCenter;

        // �X�R�A�𑦎��ɔ��f
        UpdateResultScore();
    }

    private void UpdateResultScore()
    {
        int finalScore = ScoreManager.Instance.GetScore();
        resultScoreText3D.text = finalScore.ToString();
    }
}

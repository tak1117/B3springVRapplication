using UnityEngine;

public class HomerunWall : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private GameObject hitEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallStatus ballStatus = other.GetComponent<BallStatus>();

            if (ballStatus != null && ballStatus.hasTouchedTerrain)
            {
                Debug.Log("Ball touched terrain, score is 0.");
                return; // ���_�Ȃ�
            }

            // �X�R�A�����Z
            ScoreManager.Instance.AddScore(scoreValue);

            // �G�t�F�N�g����
            if (hitEffect != null)
            {
                Instantiate(hitEffect, other.transform.position, Quaternion.identity);
            }
        }
    }
}

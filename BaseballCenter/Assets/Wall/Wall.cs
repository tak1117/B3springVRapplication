using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private bool destroyBall = true; // Inspector��ON/OFF�\

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Wall hit by: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball collided with wall!");

            // �X�R�A�����Z
            if (ScoreManager.Instance != null)
            {
                Debug.Log($"Before AddScore: {ScoreManager.Instance.GetScore()}");
                ScoreManager.Instance.AddScore(scoreValue);
                Debug.Log($"After AddScore: {ScoreManager.Instance.GetScore()}");
            }
            else
            {
                Debug.LogError("ScoreManager is null!");
            }

            // �G�t�F�N�g����
            if (hitEffect != null)
            {
                GameObject effect = Instantiate(hitEffect, collision.contacts[0].point, Quaternion.identity);
                Destroy(effect, 2f);
            }

            // �{�[�����폜�idestroyBall �� true �̏ꍇ�̂݁j
            if (destroyBall)
            {
                Destroy(collision.gameObject);
            }
        }
    }

}

using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private bool destroyBall = true; // InspectorでON/OFF可能

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Wall hit by: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball collided with wall!");

            // スコアを加算
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

            // エフェクト生成
            if (hitEffect != null)
            {
                GameObject effect = Instantiate(hitEffect, collision.contacts[0].point, Quaternion.identity);
                Destroy(effect, 2f);
            }

            // ボールを削除（destroyBall が true の場合のみ）
            if (destroyBall)
            {
                Destroy(collision.gameObject);
            }
        }
    }

}

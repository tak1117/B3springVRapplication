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
                return; // 得点なし
            }

            // スコアを加算
            ScoreManager.Instance.AddScore(scoreValue);

            // エフェクト生成
            if (hitEffect != null)
            {
                Instantiate(hitEffect, other.transform.position, Quaternion.identity);
            }
        }
    }
}

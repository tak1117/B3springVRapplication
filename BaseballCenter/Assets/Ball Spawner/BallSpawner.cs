using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;  // 発射するボールのプレハブ
    public float firstSpawnDelay = 2.0f; // 最初の発射までの時間
    public float spawnInterval = 5.0f;   // 2回目以降の発射間隔
    public float launchForce = 10.0f;    // 発射の力
    public int pitchCount = 20;  // ピッチ数

    public float xLaunchAngle = 0f;  // 発射するx軸方向の角度

    void Start()
    {
        StartCoroutine(SpawnBallRoutine());
    }

    IEnumerator SpawnBallRoutine()
    {
        yield return new WaitForSeconds(firstSpawnDelay); // 最初の発射まで2秒待つ
        for (int i = 0; i < pitchCount; i++)
        {
            SpawnBall();
            yield return new WaitForSeconds(spawnInterval); // 2回目以降は5秒ごとに発射
        }
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 発射するx軸方向の角度を直接使用
            Vector3 launchDirection = Quaternion.Euler(xLaunchAngle, 0f, 0f) * transform.forward;

            rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
        }
    }
}

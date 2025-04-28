using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;  // ���˂���{�[���̃v���n�u
    public float firstSpawnDelay = 2.0f; // �ŏ��̔��˂܂ł̎���
    public float spawnInterval = 5.0f;   // 2��ڈȍ~�̔��ˊԊu
    public float launchForce = 10.0f;    // ���˂̗�
    public int pitchCount = 20;  // �s�b�`��

    public float xLaunchAngle = 0f;  // ���˂���x�������̊p�x

    void Start()
    {
        StartCoroutine(SpawnBallRoutine());
    }

    IEnumerator SpawnBallRoutine()
    {
        yield return new WaitForSeconds(firstSpawnDelay); // �ŏ��̔��˂܂�2�b�҂�
        for (int i = 0; i < pitchCount; i++)
        {
            SpawnBall();
            yield return new WaitForSeconds(spawnInterval); // 2��ڈȍ~��5�b���Ƃɔ���
        }
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // ���˂���x�������̊p�x�𒼐ڎg�p
            Vector3 launchDirection = Quaternion.Euler(xLaunchAngle, 0f, 0f) * transform.forward;

            rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
        }
    }
}

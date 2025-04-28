using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform handTransform; // ピッチャーの右手のTransform
    public float delayBeforeThrow = 2f; // アニメーション開始からボールを投げるまでの遅延時間
    public int throwCount = 20; // 投げる回数
    public float throwInterval = 1f; // 投げる間隔

    private Animator animator;
    public Vector3 initialPosition; // 初期位置
    public Quaternion initialRotation; // **初期回転（Inspectorで設定）**

    void Start()
    {
        animator = GetComponent<Animator>();
        // **初期位置と回転を記録**
        if (initialPosition == Vector3.zero)
            initialPosition = transform.position; // Inspectorで未設定なら現在の位置を使用
        if (initialRotation == Quaternion.identity)
            initialRotation = transform.rotation; // Inspectorで未設定なら現在の回転を使用
        StartCoroutine(ThrowBalls());
    }

    IEnumerator ThrowBalls()
    {
        // 初回の遅延
        yield return new WaitForSeconds(delayBeforeThrow);

        for (int i = 0; i < throwCount; i++)
        {
            ResetTransform(); // **ループ前に座標をリセット**

            // 最後の投球でなければ間隔を空ける
            if (i < throwCount - 1)
            {
                yield return new WaitForSeconds(throwInterval);
            }
        }
    }

    void ResetTransform()
    {
        transform.position = initialPosition; // **元の位置に戻す**
        transform.rotation = initialRotation; // **Inspectorで設定した初期回転に戻す**
    }
}

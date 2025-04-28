using UnityEngine;

public class BallDisappear : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f); // 5秒後にオブジェクトを破棄
    }

    private void OnDestroy()
    {
        // CountManager が存在するかチェック
        if (CountManager.Instance != null)
        {
            // CountManager が存在している場合、カウントを減らす
            CountManager.Instance.DecreaseCount();
        }
        else
        {
            // CountManager が null の場合、警告を表示
            Debug.LogWarning("CountManager is null! Ball might have been destroyed before CountManager initialization.");
        }
    }
}

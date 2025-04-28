using UnityEngine;

public class DisplayPlayBall : MonoBehaviour
{
    public TextMesh textObject; // TextMeshProの場合
    // public Text textObject; // 通常のTextの場合
    private float displayTime = 5f; // 表示する時間（秒）
    private float delayTime = 1f; // 表示までの遅延時間（秒）

    void Start()
    {
        // 初期状態では非表示
        textObject.gameObject.SetActive(false);

        // ゲーム開始1秒後に文字を表示
        Invoke("ShowText", delayTime);
    }

    void ShowText()
    {
        textObject.gameObject.SetActive(true); // テキストを表示
        Invoke("HideText", displayTime); // 2秒後にテキストを非表示にする
    }

    void HideText()
    {
        textObject.gameObject.SetActive(false); // テキストを非表示
    }
}

using UnityEngine;
using UnityEngine.UI; // Textを使う場合
using UnityEngine.SceneManagement; // シーン遷移のため
using TMPro; // TextMeshPro用の名前空間

public class ShowFinish : MonoBehaviour
{
    public TextMesh finishText; // Textコンポーネントをインスペクターでアタッチ
    public float displayTime = 108.491f; // 文字を表示する時間
    public string sceneToLoad = "FinishScene"; // 移動したいシーン名

    void Start()
    {
        Invoke("ShowFinishText", displayTime); // 108.491秒後に文字を表示
        Invoke("LoadFinishScene", displayTime + 5f); // 113.491秒後にFinishシーンに遷移
    }

    void ShowFinishText()
    {
        finishText.text = "Finish!"; // Finish!の文字を表示
    }

    void LoadFinishScene()
    {
        SceneManager.LoadScene(sceneToLoad); // Finishシーンへ遷移
    }
}

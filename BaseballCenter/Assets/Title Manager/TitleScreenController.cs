using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class TitleScreenController : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.LeftHand; // 左手のコントローラー
    public SteamVR_Behaviour_Pose controllerPose;

    public Button[] buttons; // シーンに配置されているボタン
    private int currentButtonIndex = 0;  // 現在選択中のボタンのインデックス

    private Vector2 joystickInput;
    private float lastMoveTime = 0f;  // 最後にボタンを移動した時間
    private float moveCooldown = 0.3f; // クールダウン時間（0.3秒）

    void Update()
    {
        // ジョイスティックの東西方向を取得
        joystickInput = SteamVR_Actions.default_Move.GetAxis(inputSource);

        // ジョイスティックの東西（X軸）でボタン選択を移動
        if (Time.time - lastMoveTime > moveCooldown)
        {
            if (joystickInput.x > 0.5f) // 東方向
            {
                currentButtonIndex = Mathf.Min(currentButtonIndex + 1, buttons.Length - 1); // 次のボタンへ
                lastMoveTime = Time.time;
                Debug.Log("Button Index Moved Right: " + currentButtonIndex);
                UpdateButtonHighlight();
            }
            else if (joystickInput.x < -0.5f) // 西方向
            {
                currentButtonIndex = Mathf.Max(currentButtonIndex - 1, 0); // 前のボタンへ
                lastMoveTime = Time.time;
                Debug.Log("Button Index Moved Left: " + currentButtonIndex);
                UpdateButtonHighlight();
            }
        }

        // Aボタン（Decide）が押されたら、選択されたボタンのシーンをロード
        if (SteamVR_Actions.default_Decide.stateDown)
        {
            Debug.Log("Aボタンが押されました。シーンをロードします: " + GetCurrentSceneName());
            LoadScene();
        }

        // ボタン選択状態の更新
        UpdateButtonHighlight();
    }

    private void LoadScene()
    {
        string sceneName = GetCurrentSceneName();
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log("Loading Scene: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("シーン名が設定されていません！");
        }
    }

    private void UpdateButtonHighlight()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Image buttonImage = buttons[i].GetComponent<Image>();

            if (buttonImage != null)
            {
                if (i == currentButtonIndex)
                {
                    buttonImage.color = new Color(1f, 0.647f, 0f); // オレンジ色
                    Debug.Log("Highlighted Button: " + buttons[i].name);
                }
                else
                {
                    buttonImage.color = Color.white;
                }
            }
            else
            {
                Debug.LogWarning("Button " + buttons[i].name + " does not have an Image component.");
            }
        }

        Canvas.ForceUpdateCanvases();
    }

    public string GetCurrentSceneName()
    {
        if (buttons.Length > 0 && currentButtonIndex >= 0 && currentButtonIndex < buttons.Length)
        {
            return buttons[currentButtonIndex].name; // 選択中のボタン名（シーン名）を返す
        }
        return "";
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class toTitle : MonoBehaviour
{
    // 遷移先のシーン名をインスペクターで設定できるようにする
    public string sceneToLoad = "Title"; // デフォルトで"Title"を設定

    // SteamVR Inputのボタン設定（ここではAボタンに対応するPrimaryButton）
    public SteamVR_Action_Boolean primaryButtonAction;

    void Update()
    {
        // Aボタンが押された時
        if (primaryButtonAction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            // 設定されたシーン名に遷移
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

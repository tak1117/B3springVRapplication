using UnityEngine;
using Valve.VR;
using System.Collections.Generic;

public class a : MonoBehaviour
{
    public SteamVR_Action_Vector2 joystickInput; // ジョイスティックの入力
    public SteamVR_Input_Sources handType; // コントローラーの種類（左手 or 右手）

    public List<GameObject> targetObjects = new List<GameObject>(); // インスペクタで設定するオブジェクトリスト
    public Color highlightColor = Color.red; // ハイライトする色
    private Dictionary<GameObject, Color> originalColors = new Dictionary<GameObject, Color>(); // 元の色を保存
    private int currentIndex = 0; // 現在選択中のオブジェクト
    private float lastInputTime = 0f; // 前回の入力時間
    private float inputCooldown = 0.5f; // 入力のクールダウン時間

    void Start()
    {
        if (targetObjects.Count == 0)
        {
            Debug.LogError("targetObjects にオブジェクトを追加してください！");
            return;
        }

        // オブジェクトの元の色を保存
        foreach (GameObject obj in targetObjects)
        {
            if (obj && obj.TryGetComponent<Renderer>(out Renderer renderer))
            {
                originalColors[obj] = renderer.material.color;
            }
        }

        // 初期位置のオブジェクトをハイライト
        ChangeObjectColor(targetObjects[currentIndex]);
    }

    void Update()
    {
        if (targetObjects.Count == 0) return;

        Vector2 input = joystickInput.GetAxis(handType);

        // クールダウン時間を設定して連続入力を防ぐ
        if (Time.time - lastInputTime < inputCooldown) return;

        // 右に移動
        if (input.x > 0.5f && currentIndex < targetObjects.Count - 1)
        {
            ChangeObjectColor(targetObjects[++currentIndex]);
            lastInputTime = Time.time;
        }
        // 左に移動
        else if (input.x < -0.5f && currentIndex > 0)
        {
            ChangeObjectColor(targetObjects[--currentIndex]);
            lastInputTime = Time.time;
        }
    }

    void ChangeObjectColor(GameObject obj)
    {
        List<GameObject> objectsToRemove = new List<GameObject>(); // 削除対象のオブジェクトを格納するリスト

        // 前のオブジェクトの色を元に戻す
        foreach (var kvp in originalColors)
        {
            if (kvp.Key != null && kvp.Key.TryGetComponent<Renderer>(out Renderer renderer))
            {
                renderer.material.color = kvp.Value;
            }
            else
            {
                // オブジェクトが破棄された場合、そのエントリを削除するためにリストに追加
                objectsToRemove.Add(kvp.Key);
            }
        }

        // 削除対象のオブジェクトをoriginalColorsから削除
        foreach (var objToRemove in objectsToRemove)
        {
            originalColors.Remove(objToRemove);
        }

        // 新しいオブジェクトの色を変更
        if (obj != null && obj.TryGetComponent<Renderer>(out Renderer objRenderer))
        {
            objRenderer.material.color = highlightColor;
        }
        else
        {
            Debug.LogWarning("Attempted to change color of a destroyed object.");
        }
    }
}
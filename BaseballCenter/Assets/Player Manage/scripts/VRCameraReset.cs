using UnityEngine;
using Valve.VR;

public class VRCameraReset : MonoBehaviour
{
    public Transform vrCamera;  // VRカメラ（HMD）
    public Transform targetPosition; // 設定したいリセット位置

    private Vector3 initialOffset; // 初期位置との差分

    void Start()
    {
        if (vrCamera == null)
        {
            Debug.LogError("VRカメラが設定されていません！");
            return;
        }

        if (targetPosition == null)
        {
            Debug.LogError("ターゲット位置が設定されていません！");
            return;
        }

        // 初期オフセットを計算（ターゲット位置に合わせるため）
        initialOffset = targetPosition.position - vrCamera.position;
    }

    void Update()
    {
        if (SteamVR_Actions._default.ResetHmd.GetStateDown(SteamVR_Input_Sources.Any))
        {
            ResetCameraPosition();
        }
    }

    public void ResetCameraPosition()
    {
        if (vrCamera == null || targetPosition == null) return;

        // HMDの現在位置との差分を補正
        Vector3 offset = targetPosition.position - vrCamera.position;

        // プレイヤー全体を移動させる
        Transform player = vrCamera.parent;
        if (player != null)
        {
            player.position += offset;
        }
        else
        {
            vrCamera.position = targetPosition.position;
        }

        Debug.Log("VRカメラ位置リセット完了");
    }
}


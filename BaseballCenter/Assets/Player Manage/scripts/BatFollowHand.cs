using UnityEngine;
using Valve.VR;

public class BatFollowHand : MonoBehaviour
{
    public SteamVR_Behaviour_Pose handPose;  // 手のトラッキング情報
    public Vector3 positionOffset = new Vector3(0, 0, 0); // 手との相対位置
    public Vector3 rotationOffset = new Vector3(0, 0, 0); // 回転のオフセット

    void Start()
    {
        // Rigidbody を無効化して物理影響を受けないようにする
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void Update()
    {
        if (handPose != null)
        {
            // 手の位置にキューブを追従させる
            transform.position = handPose.transform.position + handPose.transform.rotation * positionOffset;

            // 手の回転に追従させる
            transform.rotation = handPose.transform.rotation * Quaternion.Euler(rotationOffset);
        }
    }
}
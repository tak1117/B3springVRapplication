using UnityEngine;
using Valve.VR;

public class BatFollowHand : MonoBehaviour
{
    public SteamVR_Behaviour_Pose handPose;  // ��̃g���b�L���O���
    public Vector3 positionOffset = new Vector3(0, 0, 0); // ��Ƃ̑��Έʒu
    public Vector3 rotationOffset = new Vector3(0, 0, 0); // ��]�̃I�t�Z�b�g

    void Start()
    {
        // Rigidbody �𖳌������ĕ����e�����󂯂Ȃ��悤�ɂ���
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
            // ��̈ʒu�ɃL���[�u��Ǐ]������
            transform.position = handPose.transform.position + handPose.transform.rotation * positionOffset;

            // ��̉�]�ɒǏ]������
            transform.rotation = handPose.transform.rotation * Quaternion.Euler(rotationOffset);
        }
    }
}
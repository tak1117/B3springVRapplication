using UnityEngine;
using Valve.VR;

public class VRCameraReset : MonoBehaviour
{
    public Transform vrCamera;  // VR�J�����iHMD�j
    public Transform targetPosition; // �ݒ肵�������Z�b�g�ʒu

    private Vector3 initialOffset; // �����ʒu�Ƃ̍���

    void Start()
    {
        if (vrCamera == null)
        {
            Debug.LogError("VR�J�������ݒ肳��Ă��܂���I");
            return;
        }

        if (targetPosition == null)
        {
            Debug.LogError("�^�[�Q�b�g�ʒu���ݒ肳��Ă��܂���I");
            return;
        }

        // �����I�t�Z�b�g���v�Z�i�^�[�Q�b�g�ʒu�ɍ��킹�邽�߁j
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

        // HMD�̌��݈ʒu�Ƃ̍�����␳
        Vector3 offset = targetPosition.position - vrCamera.position;

        // �v���C���[�S�̂��ړ�������
        Transform player = vrCamera.parent;
        if (player != null)
        {
            player.position += offset;
        }
        else
        {
            vrCamera.position = targetPosition.position;
        }

        Debug.Log("VR�J�����ʒu���Z�b�g����");
    }
}


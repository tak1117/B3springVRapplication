using UnityEngine;
using Valve.VR;
using System.Collections.Generic;

public class a : MonoBehaviour
{
    public SteamVR_Action_Vector2 joystickInput; // �W���C�X�e�B�b�N�̓���
    public SteamVR_Input_Sources handType; // �R���g���[���[�̎�ށi���� or �E��j

    public List<GameObject> targetObjects = new List<GameObject>(); // �C���X�y�N�^�Őݒ肷��I�u�W�F�N�g���X�g
    public Color highlightColor = Color.red; // �n�C���C�g����F
    private Dictionary<GameObject, Color> originalColors = new Dictionary<GameObject, Color>(); // ���̐F��ۑ�
    private int currentIndex = 0; // ���ݑI�𒆂̃I�u�W�F�N�g
    private float lastInputTime = 0f; // �O��̓��͎���
    private float inputCooldown = 0.5f; // ���͂̃N�[���_�E������

    void Start()
    {
        if (targetObjects.Count == 0)
        {
            Debug.LogError("targetObjects �ɃI�u�W�F�N�g��ǉ����Ă��������I");
            return;
        }

        // �I�u�W�F�N�g�̌��̐F��ۑ�
        foreach (GameObject obj in targetObjects)
        {
            if (obj && obj.TryGetComponent<Renderer>(out Renderer renderer))
            {
                originalColors[obj] = renderer.material.color;
            }
        }

        // �����ʒu�̃I�u�W�F�N�g���n�C���C�g
        ChangeObjectColor(targetObjects[currentIndex]);
    }

    void Update()
    {
        if (targetObjects.Count == 0) return;

        Vector2 input = joystickInput.GetAxis(handType);

        // �N�[���_�E�����Ԃ�ݒ肵�ĘA�����͂�h��
        if (Time.time - lastInputTime < inputCooldown) return;

        // �E�Ɉړ�
        if (input.x > 0.5f && currentIndex < targetObjects.Count - 1)
        {
            ChangeObjectColor(targetObjects[++currentIndex]);
            lastInputTime = Time.time;
        }
        // ���Ɉړ�
        else if (input.x < -0.5f && currentIndex > 0)
        {
            ChangeObjectColor(targetObjects[--currentIndex]);
            lastInputTime = Time.time;
        }
    }

    void ChangeObjectColor(GameObject obj)
    {
        List<GameObject> objectsToRemove = new List<GameObject>(); // �폜�Ώۂ̃I�u�W�F�N�g���i�[���郊�X�g

        // �O�̃I�u�W�F�N�g�̐F�����ɖ߂�
        foreach (var kvp in originalColors)
        {
            if (kvp.Key != null && kvp.Key.TryGetComponent<Renderer>(out Renderer renderer))
            {
                renderer.material.color = kvp.Value;
            }
            else
            {
                // �I�u�W�F�N�g���j�����ꂽ�ꍇ�A���̃G���g�����폜���邽�߂Ƀ��X�g�ɒǉ�
                objectsToRemove.Add(kvp.Key);
            }
        }

        // �폜�Ώۂ̃I�u�W�F�N�g��originalColors����폜
        foreach (var objToRemove in objectsToRemove)
        {
            originalColors.Remove(objToRemove);
        }

        // �V�����I�u�W�F�N�g�̐F��ύX
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
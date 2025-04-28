using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform handTransform; // �s�b�`���[�̉E���Transform
    public float delayBeforeThrow = 2f; // �A�j���[�V�����J�n����{�[���𓊂���܂ł̒x������
    public int throwCount = 20; // �������
    public float throwInterval = 1f; // ������Ԋu

    private Animator animator;
    public Vector3 initialPosition; // �����ʒu
    public Quaternion initialRotation; // **������]�iInspector�Őݒ�j**

    void Start()
    {
        animator = GetComponent<Animator>();
        // **�����ʒu�Ɖ�]���L�^**
        if (initialPosition == Vector3.zero)
            initialPosition = transform.position; // Inspector�Ŗ��ݒ�Ȃ猻�݂̈ʒu���g�p
        if (initialRotation == Quaternion.identity)
            initialRotation = transform.rotation; // Inspector�Ŗ��ݒ�Ȃ猻�݂̉�]���g�p
        StartCoroutine(ThrowBalls());
    }

    IEnumerator ThrowBalls()
    {
        // ����̒x��
        yield return new WaitForSeconds(delayBeforeThrow);

        for (int i = 0; i < throwCount; i++)
        {
            ResetTransform(); // **���[�v�O�ɍ��W�����Z�b�g**

            // �Ō�̓����łȂ���ΊԊu���󂯂�
            if (i < throwCount - 1)
            {
                yield return new WaitForSeconds(throwInterval);
            }
        }
    }

    void ResetTransform()
    {
        transform.position = initialPosition; // **���̈ʒu�ɖ߂�**
        transform.rotation = initialRotation; // **Inspector�Őݒ肵��������]�ɖ߂�**
    }
}

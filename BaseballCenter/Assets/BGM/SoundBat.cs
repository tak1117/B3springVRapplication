using UnityEngine;
using System.Collections;

public class SoundBat : MonoBehaviour
{
    private AudioSource audioSourceBat;
    public AudioClip seBat;

    void Start()
    {
        audioSourceBat = GetComponent<AudioSource>();

        // AudioSource��null�̏ꍇ�͒ǉ�����
        if (audioSourceBat == null)
        {
            audioSourceBat = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("�{�[���ƏՓ˂��܂����I");  // �f�o�b�O�p

            if (seBat != null && audioSourceBat != null)
            {
                audioSourceBat.PlayOneShot(seBat);
                Debug.Log("�����Đ����܂����I");  // �f�o�b�O�p
            }
            else
            {
                Debug.LogError("AudioClip�܂���AudioSource��null�ł��I");  // �G���[���O
            }
        }
    }
}
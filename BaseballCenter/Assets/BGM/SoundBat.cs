using UnityEngine;
using System.Collections;

public class SoundBat : MonoBehaviour
{
    private AudioSource audioSourceBat;
    public AudioClip seBat;

    void Start()
    {
        audioSourceBat = GetComponent<AudioSource>();

        // AudioSourceがnullの場合は追加する
        if (audioSourceBat == null)
        {
            audioSourceBat = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("ボールと衝突しました！");  // デバッグ用

            if (seBat != null && audioSourceBat != null)
            {
                audioSourceBat.PlayOneShot(seBat);
                Debug.Log("音を再生しました！");  // デバッグ用
            }
            else
            {
                Debug.LogError("AudioClipまたはAudioSourceがnullです！");  // エラーログ
            }
        }
    }
}
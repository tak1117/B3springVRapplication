using UnityEngine;

public class BallDisappear : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f); // 5�b��ɃI�u�W�F�N�g��j��
    }

    private void OnDestroy()
    {
        // CountManager �����݂��邩�`�F�b�N
        if (CountManager.Instance != null)
        {
            // CountManager �����݂��Ă���ꍇ�A�J�E���g�����炷
            CountManager.Instance.DecreaseCount();
        }
        else
        {
            // CountManager �� null �̏ꍇ�A�x����\��
            Debug.LogWarning("CountManager is null! Ball might have been destroyed before CountManager initialization.");
        }
    }
}

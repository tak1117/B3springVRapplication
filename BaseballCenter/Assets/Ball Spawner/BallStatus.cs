using UnityEngine;

public class BallStatus : MonoBehaviour
{
    public bool hasTouchedTerrain { get; private set; } = false; // �����l false

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            hasTouchedTerrain = true; // �n�ʂɐG�ꂽ��t���O�𗧂Ă�
        }
    }
}

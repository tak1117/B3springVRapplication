using UnityEngine;

public class BallStatus : MonoBehaviour
{
    public bool hasTouchedTerrain { get; private set; } = false; // 初期値 false

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            hasTouchedTerrain = true; // 地面に触れたらフラグを立てる
        }
    }
}

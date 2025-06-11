using System.Diagnostics;
using UnityEngine;
using Valve.VR;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 50f;

    public SteamVR_Action_Vector2 moveAction;
    public SteamVR_Action_Vector2 turnAction;

    public CharacterController characterController;

    void Start()
    {
        // 初期化ログ
        Debug.Log("PlayerMovement script started.");
        if (moveAction == null || turnAction == null)
        {
            Debug.LogWarning("SteamVR actions not assigned in Inspector.");
        }
    }

    void Update()
    {
        if (moveAction != null)
        {
            Vector2 input = moveAction.axis;
            Debug.Log("Move input: " + input); // ← ログ出力
            Vector3 move = new Vector3(input.x, 0, input.y);
            move = transform.TransformDirection(move);
            characterController.Move(move * moveSpeed * Time.deltaTime);
        }

        if (turnAction != null)
        {
            Vector2 turnInput = turnAction.axis;
            Debug.Log("Turn input: " + turnInput); // ← ログ出力
            float rotation = turnInput.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
        }
    }
}

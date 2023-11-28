using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static event Action OnIdle;
    public static event Action<bool> OnWalkingHorizontal;
    public static event Action<bool> OnWalkingVertical;

    private PlayerStats _stats;

    private float _horizontalInput;
    private float _verticalInput;

    private void Start()
    {
        _stats = GetComponent<Player>().stats;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if (_horizontalInput == 0f && _verticalInput == 0f)
        {
            OnIdle?.Invoke();
            return;
        }

        Transform playerTransform = transform;
        Vector3 direction = (playerTransform.right * _horizontalInput + playerTransform.up * _verticalInput).normalized;
        transform.Translate(direction * (Time.deltaTime * _stats.currentStats.speed));

        if (Mathf.Abs(_horizontalInput) > Mathf.Abs(_verticalInput))
        {
            OnWalkingHorizontal?.Invoke(_horizontalInput < 0f);
            return;
        }

        OnWalkingVertical?.Invoke(_verticalInput < 0f);
    }
}
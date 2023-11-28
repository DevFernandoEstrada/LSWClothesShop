using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public static event Action OnIdle;
    public static event Action<bool> OnWalkingHorizontal;
    public static event Action<bool> OnWalkingVertical;

    private PlayerStats _stats;
    private Rigidbody2D _rigidbody2D;

    private float _horizontalInput;
    private float _verticalInput;

    private void Start()
    {
        _stats = GetComponent<Player>().stats;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        CreateCollider();
    }

    private void CreateCollider()
    {
        GameObject movement = new();
        movement.name = "Physics Collider";
        movement.transform.SetParent(transform);
        CapsuleCollider2D capsuleCollider2D = movement.AddComponent<CapsuleCollider2D>();
        capsuleCollider2D.offset = new Vector2(0, 0.02f);
        capsuleCollider2D.size = new Vector2(0.15f, 0.3f);
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (_horizontalInput == 0f && _verticalInput == 0f)
        {
            _rigidbody2D.velocity = Vector2.zero;
            OnIdle?.Invoke();
            return;
        }
        
        Transform playerTransform = transform;
        Vector2 direction = (playerTransform.right * _horizontalInput + playerTransform.up * _verticalInput).normalized;
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction * (_stats.currentStats.speed * Time.fixedDeltaTime));

        if (Mathf.Abs(_horizontalInput) > Mathf.Abs(_verticalInput))
        {
            OnWalkingHorizontal?.Invoke(_horizontalInput < 0f);
            return;
        }

        OnWalkingVertical?.Invoke(_verticalInput < 0f);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayerMovement : TimeScaleBehaviour
{
    [SerializeField, Range(1, 20)]
    private float moveSpeed;
    private float direction = 0;
    private Rigidbody2D body;

    private void Awake() => body = GetComponent<Rigidbody2D>();
    private void FixedUpdate()
    {
        if (Mathf.Approximately(direction, 0)) return;
        MoveCharacter();
    }
    private void SetMoveDirection(InputAction.CallbackContext _ctx) => direction = _ctx.ReadValue<float>();
    private void MoveCharacter() => body.velocity = new Vector2( direction * moveSpeed, body.velocity.y);
}
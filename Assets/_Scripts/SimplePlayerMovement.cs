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
    private Animator animator;

    public bool isMoving                                        { get { return body.velocity.sqrMagnitude > 0f; } }

    private void Awake() 
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Approximately(direction, 0)) return;
        MoveCharacter();
    }

    public void SetMoveDirection(InputAction.CallbackContext _ctx) 
    {
        direction = _ctx.ReadValue<float>();
    }

    private void MoveCharacter() 
    {
        body.velocity = new Vector2( direction * moveSpeed, body.velocity.y);
    }
}

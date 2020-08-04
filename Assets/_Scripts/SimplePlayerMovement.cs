using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayerMovement : TimeScaleBehaviour
{
    [SerializeField, Range(1, 20)]
    private float moveSpeed;
    private float direction = 0;
    [SerializeField] float slomoTime;
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
        if( OnUpdate(slomoTime) )
        {
            if (Mathf.Approximately(direction, 0)) return;
            MoveCharacter();
        }
    }

    public void SetMoveDirection(InputAction.CallbackContext _ctx) 
    {
        direction = _ctx.ReadValue<float>();
    }

    private void MoveCharacter() 
    {
        body.position += new Vector2( direction * moveSpeed * Time.fixedDeltaTime, 0);
    }
}

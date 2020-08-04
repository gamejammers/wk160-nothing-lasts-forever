using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayerMovement : TimeScaleBehaviour
{
    [SerializeField, Range(1, 50)]
    private float moveSpeed = 10, maxSpeed = 50;
    private float direction = 0;
    private Rigidbody2D body;

    private void Awake() => body = GetComponent<Rigidbody2D>();
    private void FixedUpdate()
    {
        if (Mathf.Approximately(direction, 0)) return;
        MoveCharacter();
    }

    // The method lives here, but is never triggered from her
    public void SetMoveDirection(InputAction.CallbackContext _ctx) => direction = _ctx.ReadValue<float>();
    //

    private void MoveCharacter()
    {
        Vector2 currentPosition, nextPosition;
        currentPosition = body.position;
        nextPosition = currentPosition + new Vector2(direction * moveSpeed * Time.deltaTime, 0);
        body.position += nextPosition;
        Debug.Log("Moving");
    }
}
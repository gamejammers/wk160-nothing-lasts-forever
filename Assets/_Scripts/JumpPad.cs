using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    private float jumpStrength = 1f;
    [SerializeField]
    private string incomingObjectTag = "";
    private Collider2D collider = null;

    private void Awake() => collider = GetComponent<Collider2D>();

    public void Push(Rigidbody2D _body)
    {
        _body.AddForce(Vector2.up * jumpStrength);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(incomingObjectTag)) return;

        Debug.Log(collision.gameObject.name);

        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 collisioNormal = collider.Distance(collision.collider).normal;
        if (collisioNormal == Vector2.up)
        {
            body.velocity = Vector2.zero;
            Push(body);
        }
    }
}
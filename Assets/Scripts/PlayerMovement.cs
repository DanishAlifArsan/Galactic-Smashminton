using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private LayerMask groundLayer;
    Rigidbody2D rb;
    bool isSwing = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float _direction) {
        rb.velocity = new Vector2(speed * _direction, rb.velocity.y);
    }

    public void Jump() {
        if (isGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }
    }

    public void Swing() {
        if (!isSwing)
        {
            isSwing = true;
        }
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(col.bounds.center,col.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}

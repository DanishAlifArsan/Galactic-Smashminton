using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    BoxCollider2D col;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    public void Move(float speed, float _direction) {
        rb.velocity = new Vector2(speed * _direction, rb.velocity.y);
    }

    public void Jump(float jumpForce) {
        if (isGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(col.bounds.center,col.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}
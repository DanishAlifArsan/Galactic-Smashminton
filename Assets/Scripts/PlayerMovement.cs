using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float swingPower;
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform racket;
    [SerializeField] private float swingCooldown;
    float swingTimer = 0;
    Rigidbody2D rb;
    bool isSwing = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwing)
        {
            swingTimer += Time.deltaTime;
            racket.RotateAround(col.transform.position, new Vector3(0,0,1), swingPower * Time.deltaTime);
            if (swingTimer >= swingCooldown)
            {
                swingTimer = 0;
                isSwing = false;
            }
        }
    }

    public void Move(float _direction) {
        // transform.Translate(new Vector2(speed * _direction, transform.position.y));
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    BoxCollider2D col;
    Rigidbody2D rb;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        
        if (GameManager.instance.currentGamePhase == GamePhase.Serve || GameManager.instance.currentGamePhase == GamePhase.End)
        {
            transform.position = transform.parent.position;
            //anim.SetTrigger("Serve);
        }
    }

    public void Move(float speed, float _direction) {
        if (GameManager.instance.currentGamePhase == GamePhase.Play)
        {
            // anim.SetBool("Walk", true);
            rb.velocity = new Vector2(speed * _direction, rb.velocity.y);
        }
    }

    public void Jump(float jumpForce) {
        if (isGrounded() && GameManager.instance.currentGamePhase == GamePhase.Play) {
            // anim.SetBool("Walk", false);
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }
    }

    public bool isGrounded() {
        return Physics2D.BoxCast(col.bounds.center,col.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}

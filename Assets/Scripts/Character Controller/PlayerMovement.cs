using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private ParticleSystem jumpEffect;
    BoxCollider2D col;
    Rigidbody2D rb;
    Animator anim;
    bool isJump;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        isJump = false;
    }

    private void Update() {
        
        if (GameManager.instance.currentGamePhase == GamePhase.Serve || GameManager.instance.currentGamePhase == GamePhase.End)
        {
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y + col.bounds.size.y / 2);
            jumpEffect?.Stop();
            //anim.SetTrigger("Serve);
        }
        anim.SetBool("Jump", !isGrounded());
        anim.SetBool("Walk", rb.velocity.x != 0);

        if (isJump && rb.velocity.y < 0)
        {
            if (isGrounded())
            {
                isJump = false;
                jumpEffect?.Play();
            }
        }
    }

    public void Move(float speed, float _direction) {
        if (GameManager.instance.currentGamePhase == GamePhase.Serve || GameManager.instance.currentGamePhase == GamePhase.End)
        {
            return;
        }

        rb.velocity = new Vector2(speed * _direction, rb.velocity.y);
        if (isGrounded()) {
            AudioManager.instance.PlaySound(walkSound);
        }
    }

    public void Jump(float jumpForce) {
        if (GameManager.instance.currentGamePhase == GamePhase.Serve || GameManager.instance.currentGamePhase == GamePhase.End)
        {
            return;
        }

        if (isGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            isJump = true;
        }
    }

    public bool isGrounded() {
        return Physics2D.BoxCast(col.bounds.center,col.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}

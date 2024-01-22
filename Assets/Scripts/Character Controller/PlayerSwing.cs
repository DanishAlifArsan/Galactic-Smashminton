using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField] private float swingRange;
    [SerializeField] private LayerMask ballLayer;
    [SerializeField] private Transform playerChest;
    private Animator anim;
    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void Swing(float swingPower, Vector2 fromPosition, Vector2 targetPosition) {
        if (CheckBall() != null)
        {    
            Rigidbody2D ballRb = CheckBall().GetComponent<Rigidbody2D>();
            float v_x = (targetPosition.x - fromPosition.x)/swingPower;
            float v_y = (targetPosition.y - fromPosition.y)/swingPower + 4.9f * swingPower;

            ballRb.velocity = new Vector2(v_x, v_y);

            if (ballRb.transform.position.y > playerChest.position.y)
            {
                anim.SetTrigger("UpperSwing");
            } else {
                anim.SetTrigger("DownSwing");
            }
        } else {
            anim.SetTrigger("UpperSwing");
        }
    }

    private Collider2D CheckBall() {
        Collider2D ball = Physics2D.OverlapCircle(transform.position, swingRange, ballLayer);
        return ball;
    }

    void OnDrawGizmosSelected()
    {
        // Draw vision range circle in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, swingRange);
    }
    
} 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField] private float[] swingRange;
    [SerializeField] private LayerMask ballLayer;
    [SerializeField] private Transform playerChest;
    private Animator anim;
    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void Swing(float swingPower, Vector2 fromPosition, Vector2 targetPosition) {
        if (CheckBall() != null && MissedBall())
        {    
            Rigidbody2D ballRb = CheckBall().GetComponent<Rigidbody2D>();
            // float v_x = (targetPosition.x - fromPosition.x)/swingPower;
            // float v_y = (targetPosition.y - fromPosition.y)/swingPower + 4.9f * swingPower;
            
            float angle = 0;
            if (ballRb.transform.position.y > playerChest.position.y)
            {
                anim.SetTrigger("UpperSwing");
                angle = 30;
            } else {
                anim.SetTrigger("DownSwing");
                angle = 60;
            }

            float v_x = swingPower * Mathf.Cos(Mathf.Deg2Rad * angle);
            float v_y = swingPower * Mathf.Sin(Mathf.Deg2Rad * angle);

            ballRb.velocity = new Vector2(CalculateXVelocity(targetPosition, v_x), v_y);
            // Debug.Log(CalculateAngle(targetPosition, angle));

        } else {
            anim.SetTrigger("UpperSwing");
        }
    }

    public Collider2D CheckBall() {
        Collider2D ball = Physics2D.OverlapCircle(transform.position, swingRange[1], ballLayer);
        return ball;
    }

    public bool MissedBall() {
        Collider2D ball = Physics2D.OverlapCircle(transform.position, swingRange[0], ballLayer);
        return ball == null;
    }

    void OnDrawGizmosSelected()
    {
        // Draw vision range circle in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, swingRange[1]);
        Gizmos.DrawWireSphere(transform.position, swingRange[0]);
    }

    private float CalculateXVelocity(Vector2 targetPosition, float velocity) {
        if (transform.position.x > targetPosition.x)
        {
            return -velocity;
        } else {
            return velocity;
        }
    }
    
} 

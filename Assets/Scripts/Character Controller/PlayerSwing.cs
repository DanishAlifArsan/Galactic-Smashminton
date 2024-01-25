using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField] private float[] swingRange;
    [SerializeField] private LayerMask ballLayer;
    [SerializeField] private Transform playerChest;
    [SerializeField] private Transform smashPoint;
    private Animator anim;
    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void Swing(float swingPower, Vector2 targetPosition, bool isJump) {
        if (GameManager.instance.currentGamePhase == GamePhase.End)
        {
            return;
        }

        if (CheckBall() != null && MissedBall())
        {    
            Rigidbody2D ballRb = CheckBall().GetComponent<Rigidbody2D>();
            float v_x, v_y;
            if (GameManager.instance.currentGamePhase == GamePhase.Serve)
            {
                GameManager.instance.currentGamePhase = GamePhase.Play;
                float[] swingVelocity = Service(swingPower, ballRb);
                v_x = swingVelocity[0];
                v_y = swingVelocity[1];

            }
            else if (Vector2.Distance(ballRb.transform.position, smashPoint.transform.position) < .5f && isJump)
            {
                float[] swingVelocity = Smash(swingPower * 2, ballRb);
                v_x = swingVelocity[0];
                v_y = swingVelocity[1];
            } else {
                float[] swingVelocity = Hit(swingPower, ballRb);
                v_x = swingVelocity[0];
                v_y = swingVelocity[1];
            }
            ballRb.velocity = new Vector2(CalculateXVelocity(targetPosition, v_x), v_y);

        } else {
            anim.SetTrigger("UpperSwing");
        }
    }

    public float[] Hit(float swingPower, Rigidbody2D ballRb) {
        float angle;
        if (ballRb.transform.position.y > playerChest.position.y)
        {
            anim.SetTrigger("UpperSwing");
            angle = 30;
        } else {
            anim.SetTrigger("DownSwing");
            angle = 60;
        }

        return new float[] {swingPower * Mathf.Cos(Mathf.Deg2Rad * angle), swingPower * Mathf.Sin(Mathf.Deg2Rad * angle)};
    }

    public float[] Smash(float smashPower, Rigidbody2D ballRb) {
        // anim.SetTrigger("Smash");
        return new float[] {smashPower * Mathf.Cos(Mathf.Deg2Rad * 0), ballRb.velocity.y};
    }

    public float[] Service (float swingPower, Rigidbody2D ballRb) {
        // anim.SetTrigger("Service");
        return new float[] {swingPower * Mathf.Cos(Mathf.Deg2Rad * 60), swingPower * Mathf.Sin(Mathf.Deg2Rad * 60)};
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

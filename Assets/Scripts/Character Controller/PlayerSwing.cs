using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField] private float[] swingRange;
    [SerializeField] private LayerMask ballLayer;
    [SerializeField] private Transform playerChest;
    [SerializeField] private AudioClip hitSound;
    public Transform smashPoint;
    public Transform servePoint;
    private Animator anim;
    private void Awake() {
        anim = GetComponent<Animator>();
    }

    public void Swing(float[,] swingPowers, Vector2 targetPosition, bool isJump) {
        if (GameManager.instance.currentGamePhase == GamePhase.End || GameManager.instance.currentGamePhase == GamePhase.Score)
        {
            anim.SetTrigger("UpperSwing");
            return;
        }

        if (CheckBall() != null && MissedBall())
        {   
            Rigidbody2D ballRb = CheckBall().GetComponent<Rigidbody2D>();
            BallController ballController = CheckBall().GetComponent<BallController>();
            float v_x, v_y;
            if (GameManager.instance.currentGamePhase == GamePhase.Serve)
            {
                GameManager.instance.currentGamePhase = GamePhase.Play;
                float[] swingVelocity = Service(swingPowers[2,0], swingPowers[2,1]);
                v_x = swingVelocity[0];
                v_y = swingVelocity[1];
                ballController.HitEffect("normal");

            }
            else if (Vector2.Distance(ballRb.transform.position, smashPoint.transform.position) < .5f && isJump)
            {
                float[] swingVelocity = Smash(swingPowers[1,0], swingPowers[1,1], ballRb);
                v_x = swingVelocity[0];
                v_y = swingVelocity[1];
                ballController.HitEffect("smash");
            } else {
                float[] swingVelocity = Hit(swingPowers[0,0], swingPowers[0,1], swingPowers[2,1], ballRb);
                v_x = swingVelocity[0];
                v_y = swingVelocity[1];
                ballController.HitEffect("normal");
            }
            ballRb.velocity = new Vector2(CalculateXVelocity(targetPosition, v_x), v_y);
            AudioManager.instance.PlaySound(hitSound);

        } else {
            anim.SetTrigger("UpperSwing");
        }
    }

    public float[] Hit(float swingPower, float swingAngleUpper, float SwingAngleLower, Rigidbody2D ballRb) {
        float angle;
        if (ballRb.transform.position.y > playerChest.position.y)
        {
            anim.SetTrigger("UpperSwing");
            angle = swingAngleUpper;
        } else {
            anim.SetTrigger("DownSwing");
            angle = SwingAngleLower;
        }

        return new float[] {swingPower * Mathf.Cos(Mathf.Deg2Rad * angle), swingPower * Mathf.Sin(Mathf.Deg2Rad * angle)};
    }

    public float[] Smash(float smashPower, float swingAngle, Rigidbody2D ballRb) {
        anim.SetTrigger("UpperSwing");
        return new float[] {smashPower * Mathf.Cos(Mathf.Deg2Rad * swingAngle), ballRb.velocity.y};
    }

    public float[] Service (float swingPower, float swingAngle) {
        anim.SetTrigger("Service");
        return new float[] {swingPower * Mathf.Cos(Mathf.Deg2Rad * swingAngle), swingPower * Mathf.Sin(Mathf.Deg2Rad * 60)};
    }   

    public Collider2D CheckBall() {
        Collider2D ball = Physics2D.OverlapCircle(transform.position, swingRange[1] * transform.lossyScale.y, ballLayer);
        return ball;
    }

    public bool MissedBall() {
        Collider2D ball = Physics2D.OverlapCircle(transform.position, swingRange[0] * transform.lossyScale.y, ballLayer);
        return ball == null;
    }

    void OnDrawGizmosSelected()
    {
        // Draw vision range circle in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, swingRange[1] * transform.lossyScale.y);
        Gizmos.DrawWireSphere(transform.position, swingRange[0] * transform.lossyScale.y);
    }

    private float CalculateXVelocity(Vector2 targetPosition, float velocity) {
        if (transform.position.x > targetPosition.x)
        {
            return -velocity;
        } else {
            return velocity;
        }
    }

    public void StopParticle() {
    
    }
} 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField] private float swingCooldown;
    [SerializeField] private float swingPower;
    [SerializeField] private float swingRange;
    [SerializeField] private LayerMask ballLayer;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform playerChest;
    private float swingTimer = Mathf.Infinity;
    private bool isSwing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwing)
        {
            swingTimer += Time.deltaTime;
            if (CanSwing())
            {
                isSwing = false;
            }
        }   
    }

    public void Swing() {
        if (CanSwing())
        {
            swingTimer = 0;
            isSwing = true;
            
            if (CheckBall() != null)
            {    
                Rigidbody2D ballRb = CheckBall().GetComponent<Rigidbody2D>();
                float v_x = 0/swingPower;
                float v_y = 0/swingPower + 4.9f * swingPower;

                ballRb.velocity = new Vector2(v_x, v_y);

                // ballRb.velocity = new Vector2(swingPower,ballRb.velocity.y);

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
    }

    private bool CanSwing() {
        return swingTimer >= swingCooldown;
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

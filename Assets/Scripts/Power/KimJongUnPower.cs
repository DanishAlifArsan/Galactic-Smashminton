using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimJongUnPower : PowerSystem
{
    [SerializeField] private SpriteRenderer shadow;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float minX, maxX, posY;
    [SerializeField] private float explosionRange;
    [SerializeField] private float explosionKnockBack;
    [SerializeField] private LayerMask playerLayer;
    // private Vector2 shadowTemp, explosionTemp;

    private void Start() {
        shadow.transform.parent = null;
        shadow.enabled = false;
    }

    public override void StartPower(Rigidbody2D ballRb, BallController ballController, GameObject characterPortrait) {
        base.StartPower(ballRb, ballController, characterPortrait);

        shadow.enabled = true;
        powerGameObject.transform.localPosition = Vector3.zero;
        explosion.transform.localPosition = Vector2.zero;
        float rand = Random.Range(minX,maxX);
        ballRb.transform.position = new Vector2(rand,posY);
        shadow.transform.position = new Vector2(rand,-2.63f);
    }

    public override void EndPower()
    {
        base.EndPower();

        shadow.enabled = false;
        Collider2D[] player = Physics2D.OverlapCircleAll(shadow.transform.position, explosionRange * transform.lossyScale.y, playerLayer);
        
        foreach (var p in player)
        {
            Rigidbody2D rb = p.GetComponent<Rigidbody2D>(); 
            float appliedKnockback;
            if (rb.transform.position.x > powerGameObject.transform.position.x)
            {
                appliedKnockback = explosionKnockBack;
            } else {
                appliedKnockback = -explosionKnockBack;
            }
            rb.AddForce(new Vector2(appliedKnockback, rb.velocity.y));   
        }
        
        StartCoroutine(PlayParticle());
    }

    public IEnumerator PlayParticle() {
        explosion.Play();
        yield return new WaitWhile(() => explosion.isPlaying);
        explosion.Stop();
    }

    void OnDrawGizmosSelected()
    {
        // Draw vision range circle in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(shadow.transform.position, explosionRange * transform.lossyScale.y);
    }
}

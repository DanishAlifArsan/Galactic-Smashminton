using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public event EventHandler<OnCollideFieldArgs> OnCollideField;
    public class OnCollideFieldArgs : EventArgs {
        public string tag;
    }
    
    [SerializeField] TrailRenderer ballTrail;
    [SerializeField] ParticleSystem normalEffect, smashEffect;
    [SerializeField] Transform effectHolder;
    [SerializeField] PlayerController player;
    [SerializeField] EnemyAI enemy;

    private Transform playerServePoint, enemyServePoint, currentServePoint;
    Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerServePoint = player.servePoint;
        enemyServePoint = enemy.servePoint;
        currentServePoint = playerServePoint;
    }

    private void Update() {
        if (GameManager.instance.currentGamePhase == GamePhase.Play)
        {
            rb.gravityScale = 1;
        } else {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            if (GameManager.instance.currentGamePhase == GamePhase.Serve )
            {
                ResetPosition(currentServePoint);
            }
        }

        if (normalEffect.isPlaying || smashEffect.isPlaying)
        {
            effectHolder.parent = null;
        } else {
            effectHolder.parent = transform;
            effectHolder.localPosition = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("PlayerField"))
        {
            OnCollideField?.Invoke(this, new OnCollideFieldArgs() {tag = "player"});
            currentServePoint = enemyServePoint;
        }
        if (other.gameObject.CompareTag("EnemyField"))
        {
            OnCollideField?.Invoke(this, new OnCollideFieldArgs() {tag = "enemy"});
            currentServePoint = playerServePoint;
        }
    }

    private void ResetPosition(Transform servePoint) {
        transform.position = servePoint.position;
        ballTrail.Clear();
        normalEffect.Stop();
        smashEffect.Stop();
    }

    public void HitEffect(Material material, string tag) {
        ballTrail.material = material;
        ballTrail.enabled = true;
        switch (tag)
        {
            case "normal":
                normalEffect.Play();
                break;
            case "smash":
                smashEffect.Play();
                break;
        }
    }  
}

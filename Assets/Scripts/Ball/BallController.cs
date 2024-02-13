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
    
    [SerializeField] TrailRenderer normalTrail, smashTrail;
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
        if (GameManager.instance.currentGamePhase == GamePhase.Serve || GameManager.instance.currentGamePhase == GamePhase.End)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            ResetPosition(currentServePoint);
        } else {
            rb.gravityScale = 1;
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
        rb.velocity = Vector2.zero;
        normalTrail.Clear();
        smashTrail.Clear();
        normalEffect.Stop();
        smashEffect.Stop();
    }

    public void HitEffect(string tag) {
        switch (tag)
        {
            case "normal":
                normalTrail.enabled = true;
                smashTrail.enabled = false;
                normalEffect.Play();
                break;
            case "smash":
                normalTrail.enabled = false;
                smashTrail.enabled = true;
                smashEffect.Play();
                break;
        }
    }   
}

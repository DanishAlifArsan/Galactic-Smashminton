using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public event EventHandler<OnCollideFieldArgs> OnCollideField;
    public class OnCollideFieldArgs : EventArgs {
        public string tag;
    }
    
    [SerializeField] TrailRenderer trail;
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
        trail.Clear();
    }
}

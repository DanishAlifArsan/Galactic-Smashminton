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
    public event Func<Transform> BallPosition;
    private bool isSmash;
    public bool IsSmash { get {return isSmash;} set{isSmash = value;} }

    private PowerSystem power;
    public PowerSystem Power { get {return power;} set{power = value;} }
    
    private BallEffect effect;
    Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        effect = GetComponent<BallEffect>();
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
                ResetPosition(BallPosition?.Invoke());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("PlayerField"))
        {
            OnCollideField?.Invoke(this, new OnCollideFieldArgs() {tag = "player"});
        }
        if (other.gameObject.CompareTag("EnemyField"))
        {
            OnCollideField?.Invoke(this, new OnCollideFieldArgs() {tag = "enemy"});
        }
    }

    private void ResetPosition(Transform servePoint) {
        isSmash =false;
        power = null;
        transform.position = servePoint.position;
        HitEffect(null, null, false);
    }

    public void HitEffect(Material material, string tag, bool status = true) {
        if (status)
        {
            effect.PlayEffect(material, tag);
        } else {
            effect.StopEffect();
        }
    }  
}

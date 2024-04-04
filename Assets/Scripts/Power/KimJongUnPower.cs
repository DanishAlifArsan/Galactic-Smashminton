using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimJongUnPower : PowerSystem
{
    [SerializeField] private SpriteRenderer shadow;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float minX, maxX, posY;
    // private Vector2 shadowTemp, explosionTemp;

    private void Start() {
        shadow.transform.parent = null;
         shadow.enabled = false;
        // shadowTemp = shadow.position;
        // explosionTemp = explosion.transform.position;
    }

    public override void StartPower(Rigidbody2D ballRb, BallController ballController) {
        base.StartPower(ballRb, ballController);

        shadow.enabled = true;
        powerGameObject.transform.localPosition = Vector3.zero;
        explosion.transform.localPosition = Vector2.zero;
        float rand = Random.Range(minX,maxX);
        ballRb.transform.position = new Vector2(rand,posY);
        shadow.transform.position = new Vector2(rand,-2.39f);
    }

    // public void StartPower()
    // {
    //     // shadow.position = shadowTemp;
    //     // explosion.transform.position = explosionTemp;

    //     explosion.transform.parent = transform;
    //     transform.localPosition = Vector3.zero;
    //     explosion.transform.localPosition = Vector2.zero;
    //     float rand = Random.Range(minX,maxX);
    //     transform.parent.position = new Vector2(rand,posY);
    //     gameObject.SetActive(true);
    //     shadow.position = new Vector2(rand,-2.39f);
    // }

    // public void EndPower()
    // {
    //     shadow.parent = transform;
    //     explosion.transform.parent = null;
    //     gameObject.SetActive(false);
    //     explosion.Play();
    // }

    // private void OnTriggerEnter2D(Collider2D other) {
    //      if (other.gameObject.CompareTag("PlayerField"))
    //     {
    //         EndPower();
    //         StartCoroutine(PlayParticle());
    //     }
    // }

    public override void EndPower()
    {
        base.EndPower();
        shadow.enabled = false;
        StartCoroutine(PlayParticle());
    }

    public IEnumerator PlayParticle() {
        explosion.Play();
        yield return new WaitWhile(() => explosion.isPlaying);
        explosion.Stop();
    }
}

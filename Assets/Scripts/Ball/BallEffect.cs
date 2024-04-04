using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEffect : MonoBehaviour
{
    [SerializeField] TrailRenderer ballTrail;
    [SerializeField] ParticleSystem normalEffect, smashEffect;
    [SerializeField] Transform effectHolder;
    [SerializeField] SpriteRenderer shadow;

    private void Update() {
        if (normalEffect.isPlaying || smashEffect.isPlaying)
        {
            effectHolder.parent = null;
        } else {
            effectHolder.parent = transform;
            effectHolder.localPosition = Vector3.zero;
        }
    }
    
    public void PlayEffect(Material material, string tag) {
        shadow.enabled = true;
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

    public void StopEffect() {
        shadow.enabled = false;
        ballTrail.enabled = false;
        ballTrail.Clear();
        normalEffect.Stop();
        smashEffect.Stop();
    }
}

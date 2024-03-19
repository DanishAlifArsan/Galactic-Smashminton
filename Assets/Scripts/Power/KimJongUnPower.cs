using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimJongUnPower : MonoBehaviour, IPower
{
    [SerializeField] private Transform shadow;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float minX, maxX, posY;
    private Vector2 shadowTemp, explosionTemp;

    private void Start() {
        shadowTemp = shadow.position;
        explosionTemp = explosion.transform.position;
    }

    public void StartPower()
    {
        shadow.position = shadowTemp;
        explosion.transform.position = explosionTemp;
        shadow.parent = null;
        explosion.transform.parent = transform;
        transform.localPosition = Vector3.zero;
        explosion.transform.localPosition = Vector2.zero;
        float rand = Random.Range(minX,maxX);
        transform.parent.position = new Vector2(rand,posY);
        gameObject.SetActive(true);
        shadow.position = new Vector2(rand,-2.39f);
    }

    public void EndPower()
    {
        shadow.parent = transform;
        explosion.transform.parent = null;
        gameObject.SetActive(false);
        explosion.Play();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.CompareTag("PlayerField"))
        {
            EndPower();
        }
    }

    public void SetParent(Transform transform)
    {
        this.transform.parent = transform;
    }
}

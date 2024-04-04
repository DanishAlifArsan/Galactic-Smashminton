using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerSystem : MonoBehaviour
{
    [SerializeField] internal GameObject powerGameObject;
    [SerializeField] internal ParticleSystem powerEffect;
    bool isInit;
    public void InitPower(Rigidbody2D ballRb, BallController ballController) {
        if (!isInit)
        {
            powerGameObject.transform.parent = ballRb.transform;
            isInit = true;
        }
        
        StartPower(ballRb, ballController);
    }

    // Start is called before the first frame update
    void Start()
    {
        isInit = false;
        powerGameObject.SetActive(false);
    }

    public virtual void StartPower(Rigidbody2D ballRb, BallController ballController) {
        powerEffect.Play();
        ballController.HitEffect(null, null, false);
        ballRb.velocity = Vector2.zero;
        powerGameObject.SetActive(true);
    }

    public virtual void EndPower() {
        powerGameObject.SetActive(false);
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}

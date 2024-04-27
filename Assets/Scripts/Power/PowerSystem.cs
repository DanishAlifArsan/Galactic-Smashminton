using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerSystem : MonoBehaviour
{
    [SerializeField] internal GameObject powerGameObject;
    [SerializeField] internal ParticleSystem powerEffect;
    
    bool isInit;
    public void InitPower(Rigidbody2D ballRb, BallController ballController, GameObject characterPortrait) {
        if (!isInit)
        {
            powerGameObject.transform.parent = ballRb.transform;
            isInit = true;
        }
        
        StartPower(ballRb, ballController, characterPortrait);
    }

    // Start is called before the first frame update
    void Start()
    {
        isInit = false;
        powerGameObject.SetActive(false);
    }

    public virtual void StartPower(Rigidbody2D ballRb, BallController ballController, GameObject characterPortrait) {
        StartCoroutine(PlayEffect(ballRb, ballController, characterPortrait));
    }

    private IEnumerator PlayEffect(Rigidbody2D ballRb, BallController ballController, GameObject characterPortrait) {
        characterPortrait.SetActive(true);
        ballController.HitEffect(null, null, false);
        Time.timeScale = 0;
        powerEffect.Play();
        yield return new WaitWhile(()=> powerEffect.isPlaying);
        powerEffect.Stop();
        if (!GameManager.instance.isPaused)
        {
            Time.timeScale = 1;    
        }
        ballRb.velocity = Vector2.zero;
        powerGameObject.SetActive(true);
    }

    public virtual void EndPower() {
        powerGameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    CircleCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         col.isTrigger = true;
    //     }
    // }
    
    // private void OnCollisionExit2D(Collision2D other) {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         col.isTrigger = false;
    //     }
    // }
}

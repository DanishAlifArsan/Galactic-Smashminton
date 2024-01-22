using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // public StateManager stateManager;
    [SerializeField] private PlayableCharacter enemy;
    [SerializeField] private float enemySight;
    [SerializeField] private Transform ball;
    PlayerMovement movement;
    PlayerSwing swing;
    private bool isSwing;
    float swingTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Instantiate(enemy.prefab, transform);
        movement = obj.GetComponent<PlayerMovement>();
        swing = obj.GetComponent<PlayerSwing>();

        // stateManager = new StateManager();
        // stateManager.StartState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (BallInSight())
        {
            movement.Move(enemy.speed, Mathf.Sign(ball.position.x - transform.position.x));
            Debug.Log("in sight");
        }
    }

    public bool BallInSight() {
        return Mathf.Abs(ball.position.x - transform.position.x) < enemySight;
    }
}

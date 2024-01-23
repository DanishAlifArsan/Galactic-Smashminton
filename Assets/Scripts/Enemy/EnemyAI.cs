using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public StateManager stateManager;
    public PlayableCharacter enemy;
    [SerializeField] private float enemySight;
    public float enemyJumpSight;
    public Transform ball;
    public Transform swingTarget;
    public PlayerMovement movement;
    public PlayerSwing swing;
    public GameObject obj;
    public bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        obj = Instantiate(enemy.prefab, transform);
        movement = obj.GetComponent<PlayerMovement>();
        swing = obj.GetComponent<PlayerSwing>();

        stateManager = new StateManager();
        stateManager.StartState(this);
    }

    // Update is called once per frame
    void Update()
    {
        stateManager.currentState.UpdateState(this, stateManager);
        isJump = !movement.isGrounded();
    }

    public bool BallInSight() {
        return Mathf.Abs(ball.position.x - transform.position.x) < enemySight || ball.position.x > obj.transform.position.x;
    }
}

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
    public Transform servePoint;
    public bool isJump;

    // Start is called before the first frame update
    void Awake()
    {
        enemy = CharacterSelect.instance.selectedCharacter;
        obj = Instantiate(enemy.prefab, transform);
        movement = obj.GetComponent<PlayerMovement>();
        swing = obj.GetComponent<PlayerSwing>();
        servePoint = swing.servePoint;

        stateManager = new StateManager();
        stateManager.StartState(this);
    }

    // Update is called once per frame
    void Update()
    {
        stateManager.currentState.UpdateState(this, stateManager);
        isJump = !movement.isGrounded();
        stateManager.SwitchAnyState(this, stateManager.enemyServe, () => GameManager.instance.currentGamePhase == GamePhase.Serve);
    }

    public bool BallInSight() {
        return Mathf.Abs(ball.position.x - transform.position.x) < enemySight || ball.position.x > obj.transform.position.x;
    }
}

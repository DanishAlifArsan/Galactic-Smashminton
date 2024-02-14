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
    [SerializeField] Transform indicator;
    public PlayerMovement movement;
    public PlayerSwing swing;
    public GameObject obj;
    public Transform servePoint;
    public bool isJump;
    public float[,] swingPowers;

    // Start is called before the first frame update
    void Awake()
    {
        enemy = CharacterSelect.instance.selectedCharacter;
        obj = Instantiate(enemy.prefab, transform).transform.GetChild(0).gameObject;
        movement = obj.GetComponent<PlayerMovement>();
        swing = obj.GetComponent<PlayerSwing>();
        servePoint = swing.servePoint;
        indicator.parent = obj.transform;
        indicator.localPosition = swing.smashPoint.localPosition;
        PopulateArray();

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

    private void PopulateArray() {
        swingPowers = new float[3,3];
        swingPowers[0,0] = enemy.swingPower;
        swingPowers[0,1] = enemy.swingAngle;
        swingPowers[1,0] = enemy.smashPower;
        swingPowers[1,1] = enemy.smashAngle;
        swingPowers[2,0] = enemy.servicePower;
        swingPowers[2,1] = enemy.serviceAngle;
    }
}

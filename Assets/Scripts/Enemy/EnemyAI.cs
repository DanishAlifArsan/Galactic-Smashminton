using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : CharController
{
    public StateManager stateManager;
    public PlayableCharacter enemy;
    [SerializeField] private float enemySight;
    [SerializeField] private Image powerPortrait;
    
    public float enemyJumpSight;
    public Transform ball;
    public Transform swingTarget;

    // Start is called before the first frame update
    void Awake()
    {
        enemy = CharacterSelect.instance.selectedCharacter;
        InitCharacter(enemy);
        powerPortrait.sprite = enemy.portrait;
        swing.characterPortrait = powerPortrait.gameObject;

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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public IState currentState;
    public EnemyIdleState enemyIdle = new EnemyIdleState();
    public EnemyWalkingState enemyWalk = new EnemyWalkingState();
    public EnemyJumpState enemyJump = new EnemyJumpState();
    public EnemySwingState enemySwing = new EnemySwingState();
    
    // Start is called before the first frame update
    public void StartState(EnemyAI enemy)
    {
        currentState = enemyIdle;
        currentState.EnterState(enemy, this);
    }

    public void SwitchState(EnemyAI enemy, IState state) {
        currentState = state;
        state.EnterState(enemy, this);
    }
}
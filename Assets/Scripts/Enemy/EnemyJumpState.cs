using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpState : IState
{
    public void EnterState(EnemyAI enemy, StateManager stateManager)
    {
        
    }

    public void UpdateState(EnemyAI enemy, StateManager stateManager)
    {
        enemy.movement.Jump(enemy.enemy.jumpForce);

        if (enemy.swing.CheckBall() != null)
       {
        stateManager.SwitchState(enemy, stateManager.enemySwing);
       } else {
        stateManager.SwitchState(enemy, stateManager.enemyIdle);
       }
    }
}

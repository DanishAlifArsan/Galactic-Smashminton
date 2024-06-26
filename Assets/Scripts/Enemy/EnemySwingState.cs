using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwingState : IState
{
    public void EnterState(EnemyAI enemy, StateManager stateManager)
    {
        if (Random.Range(1,10) < 9)
        {
            enemy.swing.Swing(enemy.swingPowers, enemy.swingTarget.position, enemy.isJump);
        }
    }

    public void UpdateState(EnemyAI enemy, StateManager stateManager)
    {
        if (enemy.swing.CheckBall() == null)
        {
            stateManager.SwitchState(enemy, stateManager.enemyIdle);
        }
    }
}

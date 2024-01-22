using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwingState : IState
{
    public void EnterState(EnemyAI enemy, StateManager stateManager)
    {
        enemy.swing.Swing(enemy.enemy.swingPower, enemy.transform.position, enemy.swingTarget.position);
    }

    public void UpdateState(EnemyAI enemy, StateManager stateManager)
    {
        if (enemy.swing.CheckBall() == null)
        {
            stateManager.SwitchState(enemy, stateManager.enemyIdle);
        }
    }
}

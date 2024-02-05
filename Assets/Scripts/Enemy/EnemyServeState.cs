using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyServeState : IState
{
    public void EnterState(EnemyAI enemy, StateManager stateManager)
    {
        if (enemy.BallInSight())
        {
            enemy.GetComponent<MonoBehaviour>().StartCoroutine(Serve(enemy, stateManager));
        }
    }

    public void UpdateState(EnemyAI enemy, StateManager stateManager)
    {
        if (!enemy.BallInSight())
        {
            stateManager.SwitchState(enemy, stateManager.enemyIdle);
        }
    }

    private IEnumerator Serve(EnemyAI enemy, StateManager stateManager) {
        yield return new WaitForSeconds(1);
        enemy.swing.Swing(enemy.enemy.swingPower, enemy.swingTarget.position, false);
    }
}

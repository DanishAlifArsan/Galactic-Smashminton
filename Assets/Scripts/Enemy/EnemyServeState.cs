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
        } else {
            stateManager.SwitchState(enemy, stateManager.enemyIdle);
        }
    }

    public void UpdateState(EnemyAI enemy, StateManager stateManager)
    {
    
    }

    private IEnumerator Serve(EnemyAI enemy, StateManager stateManager) {
        yield return new WaitForSeconds(1);
        enemy.swing.Swing(enemy.swingPowers, enemy.swingTarget.position, false);
        yield return new WaitUntil(() => !enemy.BallInSight());
        stateManager.SwitchState(enemy, stateManager.enemyIdle);
    }
}

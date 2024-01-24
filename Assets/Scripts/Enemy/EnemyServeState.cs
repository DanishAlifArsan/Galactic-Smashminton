using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyServeState : IState
{
    public void EnterState(EnemyAI enemy, StateManager stateManager)
    {
        if (enemy.swing.CheckBall() != null)
        {
            enemy.GetComponent<MonoBehaviour>().StartCoroutine(Serve(enemy, stateManager));
        }
    }

    public void UpdateState(EnemyAI enemy, StateManager stateManager)
    {
        
    }

    private IEnumerator Serve(EnemyAI enemy, StateManager stateManager) {
        yield return new WaitForSeconds(1);
        stateManager.SwitchState(enemy, stateManager.enemySwing);
    }
}

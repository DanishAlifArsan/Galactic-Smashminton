using UnityEngine;

public class EnemyIdleState : IState
{
    public void EnterState(EnemyAI enemy, StateManager stateManager)
    {
       
    }

    public void UpdateState(EnemyAI enemy, StateManager stateManager)
    {
        if (enemy.BallInSight())
        {
            stateManager.SwitchState(enemy, stateManager.enemyWalk);
        }
    }
}

using UnityEngine;

public class EnemyWalkingState : IState
{
    public void EnterState(EnemyAI enemy, StateManager stateManager)
    {
        
    }

    public void UpdateState(EnemyAI enemy, StateManager stateManager)
    {
       enemy.movement.Move(enemy.enemy.speed, Mathf.Sign(enemy.ball.position.x - enemy.obj.transform.position.x));
       if (Mathf.Abs(enemy.ball.position.x - enemy.obj.transform.position.x) < .1f && 
        enemy.ball.position.y - enemy.obj.transform.position.y < enemy.enemyJumpSight)
       {
        stateManager.SwitchState(enemy, stateManager.enemyJump);
       }

       if (!enemy.BallInSight())
       {
        stateManager.SwitchState(enemy, stateManager.enemyIdle);
       }

       if (enemy.swing.CheckBall() != null && enemy.swing.MissedBall())
       {
        stateManager.SwitchState(enemy, stateManager.enemySwing);
       }
    }
}

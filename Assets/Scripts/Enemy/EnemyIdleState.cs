// using UnityEngine;

// public class EnemyIdleState : IState
// {
//     private float idleTimer = 0f;

//     // public override void EnterState(Enemy enemy, StateManager stateManager)
//     // {
//     //     enemy.animator.SetInteger("AnimState", 0);
//     // }

//     // public override void UpdateState(Enemy enemy, StateManager stateManager)
//     // {
//     //     if (enemy.playerInSight())
//     //     {
//     //         idleTimer = 0f;
//     //         stateManager.SwitchState(enemy, stateManager.enemyAttackState);
//     //     }

//     //     if (idleTimer < enemy.idleDuration)
//     //     {
//     //         idleTimer += Time.deltaTime;
//     //     } else {
//     //         idleTimer = 0f;
//     //         stateManager.SwitchState(enemy, stateManager.enemyWalkingState);
//     //     }
//     // }

//     //   public override void DamagePlayer(Enemy enemy)
//     // {
       
//     // }

//     // public override void Deactivate(Enemy enemy)
//     // {
        
//     // }

//     public void EnterState(EnemyAI enemy, StateManager stateManager)
//     {
//         throw new System.NotImplementedException();
//     }

//     public void UpdateState(EnemyAI enemy, StateManager stateManager)
//     {
//         throw new System.NotImplementedException();
//     }
// }

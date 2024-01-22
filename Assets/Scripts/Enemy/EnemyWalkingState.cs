// using UnityEngine;

// public class EnemyWalkingState : BaseState
// {
//     private Vector2 initScale;
//     private bool movingLeft;

//     public override void EnterState(Enemy enemy, StateManager stateManager)
//     {
//       enemy.animator.SetInteger("AnimState", 2);
//       initScale = enemy.transform.localScale;
//     }

//     public override void UpdateState(Enemy enemy, StateManager stateManager)
//     {
//         if (enemy.playerInSight())
//         {
//             stateManager.SwitchState(enemy, stateManager.enemyIdleState);
//         }

//         if(movingLeft) {
//             if (enemy.transform.position.x >= enemy.leftEdge.position.x)
//             {
//                 moveInDirection(enemy,-1);
//             } else {
//                 movingLeft = !movingLeft;
//                 stateManager.SwitchState(enemy, stateManager.enemyIdleState);
//             }
            
//         } else {
//             if (enemy.transform.position.x <= enemy.rightEdge.position.x) {
//                 moveInDirection(enemy,1);
//             } else {
//                 movingLeft = !movingLeft;
//                 stateManager.SwitchState(enemy, stateManager.enemyIdleState);
//             }
//         }
//     }
//     private void moveInDirection(Enemy enemy, int _direction) {
//         enemy.transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y);
//         enemy.transform.position = new Vector2(enemy.transform.position.x + Time.deltaTime * enemy.movementSpeed * _direction,
//         enemy.transform.position.y);
//     }

//     public override void DamagePlayer(Enemy enemy)
//     {
      
//     }

//     public override void Deactivate(Enemy enemy)
//     {
        
//     }
// }

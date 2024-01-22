// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;

// public class StateManager : MonoBehaviour
// {
//     public IState currentState;
//     public EnemyIdleState enemyIdleState = new EnemyIdleState();
//     public EnemyWalkingState enemyWalkingState = new EnemyWalkingState();
//     public EnemyAttackState enemyAttackState = new EnemyAttackState();
//     public EnemyDeathState enemyDeathState = new EnemyDeathState();
    
//     // Start is called before the first frame update
//     public void StartState(EnemyAI enemy)
//     {
//         currentState = enemyIdleState;
//         currentState.EnterState(enemy, this);
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public void SwitchState(EnemyAI enemy, IState state) {
//         currentState = state;
//         state.EnterState(enemy, this);
//     }
// }

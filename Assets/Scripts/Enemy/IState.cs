using UnityEngine;

public interface IState
{
    void EnterState(EnemyAI enemy, StateManager stateManager);
    void UpdateState(EnemyAI enemy, StateManager stateManager);
}

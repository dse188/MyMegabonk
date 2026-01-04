using UnityEngine;

public class Enemy_ChaseState : Enemy_BaseState
{
    public override void EnterState(Enemy_StateManager enemy)
    {
        // Enable chase behavior
        enemy.Brain.enabled = true;
    }

    public override void UpdateState(Enemy_StateManager enemy)
    {
        // Chase logic lives in EnemyBrain (FixedUpdate)
        // State can remain empty unless extra decisions later
    }
}

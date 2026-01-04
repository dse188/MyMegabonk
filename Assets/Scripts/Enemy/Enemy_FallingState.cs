using UnityEngine;

public class Enemy_FallingState : Enemy_BaseState
{
    public override void EnterState(Enemy_StateManager enemy)
    {
        // Disable chasing while falling
        enemy.Brain.enabled = false;

        // If enemy somehow spawns while already touching something, switch instantly
        if (enemy.FallHandler.Landed)
            enemy.SwitchState(enemy.chaseState);
    }

    public override void UpdateState(Enemy_StateManager enemy)
    {
        // The moment enemy lands, switch to chase
        if (enemy.FallHandler.Landed)
            enemy.SwitchState(enemy.chaseState);
    }
}

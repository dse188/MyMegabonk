using UnityEngine;

public class Enemy_StateManager : MonoBehaviour
{
    Enemy_BaseState currentState;
    
    public Enemy_FallingState fallingState = new Enemy_FallingState();
    public Enemy_ChaseState chaseState = new Enemy_ChaseState();

    public EnemyFallHandler FallHandler { get; private set; }
    public EnemyBrain Brain { get; private set; }

    private void Awake()
    {
        FallHandler = GetComponent<EnemyFallHandler>();
        Brain = GetComponent<EnemyBrain>();

        if (FallHandler == null) Debug.LogError("Missing EnemyFallHandler on enemy.");
        if (Brain == null) Debug.LogError("Missing EnemyBrain on enemy.");
    }

    private void Start()
    {
        SwitchState(fallingState);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(Enemy_BaseState newState)
    {
        if (newState == null) return;

        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}

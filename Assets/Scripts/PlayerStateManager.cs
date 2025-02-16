using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    public PlayerBaseState currentState;
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerRunningState runningState = new PlayerRunningState();

    private void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(PlayerBaseState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
            currentState.EnterState(this);
        }
    }

}

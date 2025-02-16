using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        Debug.Log("Enter State: IDLE");
    }

    public override void UpdateState(PlayerStateManager playerStateManager)
    {
        if (PlayerInputManager.Instance.inputTest1.IsPressed())
        {
            playerStateManager.ChangeState(playerStateManager.runningState);
        }
    }

}

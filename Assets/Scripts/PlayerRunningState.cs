using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        Debug.Log("Enter State: RUNNING");
    }

    public override void UpdateState(PlayerStateManager playerStateManager)
    {
        if (PlayerInputManager.Instance.inputTest2.IsPressed())
        {
            playerStateManager.ChangeState(playerStateManager.idleState);
        }
    }

}

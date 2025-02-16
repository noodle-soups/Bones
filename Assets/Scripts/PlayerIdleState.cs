using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Enter State: IDLE");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (PlayerInputManager.Instance.GetMovementInput() != Vector3.zero)
        {
            player.ChangeState(player.runningState);
        }
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        // nothing
    }

}

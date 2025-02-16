using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    // variables
    private string animBoolName = "isIdle";


    public override void EnterState(PlayerStateManager player)
    {
        player.anim.SetBool(animBoolName, true);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        HandleStateTransition(player);
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        // nothing
    }

    public override void ExitState(PlayerStateManager player)
    {
        player.anim.SetBool(animBoolName, false);
    }

    private static void HandleStateTransition(PlayerStateManager player)
    {
        if (PlayerInputManager.Instance.GetMovementInput() != Vector3.zero)
            player.ChangeState(player.runningState);

        if (PlayerInputManager.Instance.attack.IsPressed())
            player.ChangeState(player.attackingState);
    }

}

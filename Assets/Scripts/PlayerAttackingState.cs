using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{

    private string animBoolName = "isAttacking";

    public override void EnterState(PlayerStateManager player)
    {
        player.anim.SetBool(animBoolName, true);
    }

    public override void ExitState(PlayerStateManager player)
    {
        player.anim.SetBool(animBoolName, false);
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        // nothing
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (!player.anim.IsAnimationPlaying("Player_Attack"))
            player.ChangeState(player.idleState);
    }

}

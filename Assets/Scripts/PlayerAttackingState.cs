using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{

    private string animBoolName = "isAttacking";
    //private BoxCollider swordCollider;

    public override void EnterState(PlayerStateManager player)
    {
        player.anim.SetBool(animBoolName, true);
        //swordCollider = player.swordWeapon.GetComponent<BoxCollider>();
        //swordCollider.enabled = true;
    }

    public override void ExitState(PlayerStateManager player)
    {
        player.anim.SetBool(animBoolName, false);
        //swordCollider.enabled = false;
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        // nothing
    }

    public override void UpdateState(PlayerStateManager player)
    {
        HandleStateTransitions(player);
    }

    private static void HandleStateTransitions(PlayerStateManager player)
    {
        if (!player.anim.IsAnimationPlaying("Player_Attack"))
        {
            player.ChangeState(player.idleState);
        }
    }

}

using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRunningState : PlayerBaseState
{

    // scripts
    private PlayerData playerData;

    // variables
    private Vector3 moveInput;
    private string animBoolName = "isRunning";

    public PlayerRunningState(PlayerData data)
    {
        playerData = data;
    }

    public override void EnterState(PlayerStateManager player)
    {
        player.anim.SetBool(animBoolName, true);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        HandleStateTransitions(player);
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        HandleMovement(player);
    }

    private void HandleMovement(PlayerStateManager player)
    {
        moveInput = PlayerInputManager.Instance.GetMovementInput();
        Quaternion _targetRotation = Quaternion.LookRotation(moveInput);

        player.tr.rotation = Quaternion.Slerp(player.tr.rotation, _targetRotation, 50f * Time.fixedDeltaTime);
        player.tr.Translate(Vector3.forward * playerData.runSpeed * Time.fixedDeltaTime);
    }

    public override void ExitState(PlayerStateManager player)
    {
        player.anim.SetBool(animBoolName, false);
    }

    private static void HandleStateTransitions(PlayerStateManager player)
    {
        if (PlayerInputManager.Instance.GetMovementInput() == Vector3.zero)
        {
            player.ChangeState(player.idleState);
        }
    }

}

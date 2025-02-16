using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRunningState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Enter State: RUNNING");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (PlayerInputManager.Instance.GetMovementInput() == Vector3.zero)
        {
            player.ChangeState(player.idleState);
        }
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        Vector3 _movementInput = PlayerInputManager.Instance.GetMovementInput();
        player.tr.Translate(Vector3.forward * 10f * Time.fixedDeltaTime);
    }

}

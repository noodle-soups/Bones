using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRunningState : PlayerBaseState
{

    private PlayerData playerData;

    public PlayerRunningState(PlayerData data)
    {
        playerData = data;
    }

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
        Quaternion _targetRotation = Quaternion.LookRotation(_movementInput);

        player.tr.rotation = Quaternion.Slerp(player.tr.rotation, _targetRotation, 50f * Time.fixedDeltaTime);
        player.tr.Translate(Vector3.forward * playerData.runSpeed * Time.fixedDeltaTime);
    }

}

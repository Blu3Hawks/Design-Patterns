using UnityEngine;

public class WalkRightState : StateMachine
{
    public WalkRightState(PlayerController playerController) : base(playerController)
    {
        _playerController.PlayerDirection = Vector3.right;
    }

    public override void OnJumpClick(PlayerController characterController)
    {
        _playerController.SetState(new JumpState(_playerController));
    }

    public override void OnLeftClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkLeftState(_playerController));
    }

    public override void OnBackwardClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkBackwardsState(_playerController));
    }
    public override void OnForwardClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkForwardState(_playerController));
    }
    public override void OnRightReleaseClick(PlayerController characterController)
    {
        _playerController.SetState(new IdleState(characterController));
    }
}

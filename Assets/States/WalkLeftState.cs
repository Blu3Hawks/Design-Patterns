using UnityEngine;

public class WalkLeftState : StateMachine
{
    public WalkLeftState(PlayerController playerController) : base(playerController)
    {
        _playerController.PlayerDirection = Vector3.left;
    }

    public override void OnJumpClick(PlayerController characterController)
    {
        _playerController.SetState(new JumpState(_playerController));
    }

    public override void OnRightClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkRightState(_playerController));
    }

    public override void OnBackwardClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkBackwardsState(_playerController));
    }
    public override void OnForwardClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkForwardState(_playerController));
    }
    public override void OnLeftReleaseClick(PlayerController characterController)
    {
        _playerController.SetState(new IdleState(characterController));
    }
}

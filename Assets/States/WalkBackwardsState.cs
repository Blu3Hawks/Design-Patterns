using UnityEngine;

public class WalkBackwardsState : StateMachine
{
    public WalkBackwardsState(PlayerController playerController) : base(playerController)
    {
        _playerController.PlayerDirection = Vector3.back;
    }

    public override void OnJumpClick(PlayerController characterController)
    {
        _playerController.SetState(new JumpState(_playerController));
    }

    public override void OnLeftClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkLeftState(_playerController));
    }

    public override void OnRightClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkRightState(_playerController));
    }
    public override void OnForwardClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkForwardState(_playerController));
    }
    public override void OnBackwardReleaseClick(PlayerController characterController)
    {
        _playerController.SetState(new IdleState(characterController));

    }
}
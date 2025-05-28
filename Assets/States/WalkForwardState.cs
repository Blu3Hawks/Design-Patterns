using UnityEngine;

public class WalkForwardState : StateMachine
{
    public WalkForwardState(PlayerController playerController) : base(playerController)
    {
        _playerController.PlayerDirection = Vector3.forward; 
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
    public override void OnBackwardClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkBackwardsState(_playerController));
    }
    public override void OnForwardReleaseClick(PlayerController characterController)
    {
        _playerController.SetState(new IdleState(characterController));
    }

}
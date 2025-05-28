using UnityEngine;

public class IdleState : StateMachine
{
    public IdleState(PlayerController characterController) : base(characterController)
    {
        _playerController.PlayerDirection = Vector3.zero;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnForwardClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkForwardState(_playerController));
    }
    public override void OnBackwardClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkBackwardsState(_playerController));
    }
    public override void OnRightClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkRightState(_playerController));
    }
    public override void OnLeftClick(PlayerController characterController)
    {
        _playerController.SetState(new WalkLeftState(_playerController));
    }
    public override void OnJumpClick(PlayerController characterControler)
    {
        _playerController.SetState(new JumpState(_playerController));
    }
}


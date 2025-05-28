using UnityEngine;
public class JumpState : StateMachine
{
    public JumpState(PlayerController playerController) : base(playerController)
    {
        _playerController.VerticalVelocity = _playerController.JumpForce;
    }

    public override void Update()
    {
        base.Update();
        _playerController.UpdateActivePlayerState();
    }

    public override void OnLeftClick(PlayerController characterController)
    {
        _playerController.PlayerDirection = Vector3.left;
    }

    public override void OnRightClick(PlayerController characterController)
    {
        _playerController.PlayerDirection = Vector3.right;
    }

    public override void OnForwardClick(PlayerController characterController)
    {
        _playerController.PlayerDirection = Vector3.forward;
    }

    public override void OnBackwardClick(PlayerController characterController)
    {
        _playerController.PlayerDirection = Vector3.back;
    }
}

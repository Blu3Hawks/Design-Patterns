using UnityEngine;

public class StateMachine
{
    protected PlayerController _playerController;
    public StateMachine(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public virtual void Update()
    {
        _playerController.VerticalVelocity += _playerController.Gravity * Time.deltaTime;

        Vector3 movementVector = (_playerController.PlayerDirection * _playerController.MovementSpeed) +
                       (Vector3.up * _playerController.VerticalVelocity);

        _playerController.CharacterController.Move(movementVector * Time.deltaTime);
    }


    public virtual void OnForwardClick(PlayerController characterController) { }
    public virtual void OnBackwardClick(PlayerController characterController) { }
    public virtual void OnRightClick(PlayerController characterController) { }
    public virtual void OnLeftClick(PlayerController characterController) { }
    public virtual void OnJumpClick(PlayerController characterController) { }
    public virtual void OnRightReleaseClick(PlayerController characterController) { }
    public virtual void OnLeftReleaseClick(PlayerController characterController) { }
    public virtual void OnForwardReleaseClick(PlayerController characterController) { }
    public virtual void OnBackwardReleaseClick(PlayerController characterController) { }

}

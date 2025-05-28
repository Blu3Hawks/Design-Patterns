using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //references
    [Header("Character Components")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject _playerModel;
    [SerializeField] private float _movementSpeed = 5f;

    [Header("Gravity stuff")]
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpForce = 5f;

    //properties
    public CharacterController CharacterController { get { return _characterController; } }
    public Vector3 PlayerDirection { get; set; }
    public float MovementSpeed { get { return _movementSpeed; } }
    public Vector2 PlayerInput { get; private set; }

    private float _verticalVelocity;
    public bool IsGrounded => _characterController.isGrounded;
    public float Gravity => _gravity;
    public float JumpForce => _jumpForce;

    public float VerticalVelocity
    {
        get => _verticalVelocity;
        set => _verticalVelocity = value;
    }

    private StateMachine currentState;
    private Vector2 _lastInput = Vector2.zero;


    private void Awake()
    {
        currentState = new IdleState(this);
    }

    private void Update()
    {
        currentState.Update();
    }

    public void OnPlayerMovement(InputAction.CallbackContext context)
    {
        if (!context.performed && !context.canceled) return;

        if (context.performed)
        {

            PlayerInput = context.ReadValue<Vector2>();
            UpdateActivePlayerState();
        }
        else if (context.canceled)
        {
            UpdateInactivePlayerState();
        }
    }

    public void UpdateInactivePlayerState()
    {
        PlayerInput = Vector2.zero;
        //PlayerDirection = Vector3.zero;
        _lastInput = Vector2.zero;

        currentState.OnForwardReleaseClick(this);
        currentState.OnBackwardReleaseClick(this);
        currentState.OnLeftReleaseClick(this);
        currentState.OnRightReleaseClick(this);

        SetState(new IdleState(this));
    }

    public void UpdateActivePlayerState()
    {
        if (_lastInput == PlayerInput) return;
        _lastInput = PlayerInput;

        if (PlayerInput == Vector2.zero)
        {
            SetState(new IdleState(this));
            return;
        }

        Vector3 direction = new Vector3(PlayerInput.x, 0, PlayerInput.y).normalized;
        PlayerDirection = direction;

        if (PlayerInput.y > 0)
            currentState.OnForwardClick(this);
        else if (PlayerInput.y < 0)
            currentState.OnBackwardClick(this);
        else if (PlayerInput.x > 0)
            currentState.OnRightClick(this);
        else if (PlayerInput.x < 0)
            currentState.OnLeftClick(this);

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentState.OnJumpClick(this);
        }
    }

    public void SetState(StateMachine newState)
    {
        currentState = newState;
    }
}

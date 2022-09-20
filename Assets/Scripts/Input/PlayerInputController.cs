using System;
using Player.Intefaces;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputController : IPlayerInputController, IDisposable
{
    private readonly PlayerMovement _playerMovement;
    private readonly PlayerInput _playerInput;
    private readonly InputAction _moveAction;
    private readonly InputAction _jumpAction;

    public PlayerInputController(PlayerMovement playerMovement, PlayerInput playerInput)
    {
        _playerInput = playerInput;
        _playerMovement = playerMovement;

        _moveAction = _playerInput.actions["Move"];
        _jumpAction = _playerInput.actions["Jump"];

        _jumpAction.performed += JumpInput;
    }

    public void UpdateInput()
    {
        _playerMovement.Move(_moveAction.ReadValue<Vector2>());
    }

    public void Dispose()
    {
        _jumpAction.started -= JumpInput;

        _moveAction?.Dispose();
        _jumpAction?.Dispose();
    }

    private void MoveInput(InputAction.CallbackContext context)
    {
        // _playerMovement.Move(context.ReadValue<Vector2>());
    }
    
    private void JumpInput(InputAction.CallbackContext context)
    {
        _playerMovement.Jump();
    }
}
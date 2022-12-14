using System;
using Player.Intefaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComposition : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody2D playerRigidbody2D;

    private IPlayerInputController _inputController;
    private PlayerMovement _playerMovement;
    public void Construct()
    {
        _playerMovement = new PlayerMovement(_inputController, playerRigidbody2D);
        _inputController = new PlayerInputController(_playerMovement, playerInput);
    }

    private void Update()
    {
        _inputController.UpdateInput();
    }
}

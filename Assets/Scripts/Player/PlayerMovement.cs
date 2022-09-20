using Player.Intefaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement
{
    private IPlayerInputController _input;
    private readonly Rigidbody2D _rigidbody2D;
    private float _moveSpeed = 7;
    private float _jumpForce = 1300;

    private LayerMask _groundLayers;
    private bool _grounded = true;
    private float _groundedOffset = 0;
    private float _groundedRadius = 1f;

    public PlayerMovement(IPlayerInputController input, Rigidbody2D rigidbody2D)
    {
        _input = input;
        _rigidbody2D = rigidbody2D;
        _groundLayers = LayerMask.GetMask("Ground");
    }


    public void Move(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            var currentDir = direction;
            
            _rigidbody2D.velocity = new Vector2(currentDir.x * _moveSpeed, _rigidbody2D.velocity.y);
        }
    }

    public void Jump()
    {
        if (GroundedCheck())
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private bool GroundedCheck()
    {
        Vector2 spherePosition = new Vector2(_rigidbody2D.gameObject.transform.position.x,
            _rigidbody2D.gameObject.transform.position.y - _groundedOffset);
        _grounded = Physics2D.OverlapCircle(spherePosition, _groundedRadius, _groundLayers);
        return _grounded;
    }

    private bool WallCheck()
    {
        Vector2 spherePosition = new Vector2(_rigidbody2D.gameObject.transform.position.x,
            _rigidbody2D.gameObject.transform.position.y);
        var grounded = Physics2D.OverlapCircle(spherePosition, _groundedRadius, LayerMask.GetMask("Walls"));
        return grounded;
    }
}
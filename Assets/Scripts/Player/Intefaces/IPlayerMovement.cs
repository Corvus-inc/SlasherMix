using UnityEngine;

namespace Player.Intefaces
{
    public interface IPlayerMovement
    {
        public void Move(Vector2 direction);
        public void Jump();
    }
}
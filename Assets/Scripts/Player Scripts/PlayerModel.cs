using UnityEngine;

namespace Hunter.Player
{
    public class PlayerModel
    {
        private PlayerController playerController;

        public float speed { get; private set; }
        public float health { get; private set; }

        public PlayerModel(float _speed, float _health)
        {
            speed = _speed;
            health = _health;
        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }
    }
}

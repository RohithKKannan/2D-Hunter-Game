using UnityEngine;

namespace Hunter.Player
{
    public class PlayerModel
    {
        private PlayerController playerController;

        private float speed;

        public PlayerModel(float _speed)
        {
            speed = _speed;
        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }
    }
}

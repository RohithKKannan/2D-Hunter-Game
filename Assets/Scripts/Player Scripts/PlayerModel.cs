using UnityEngine;

namespace Hunter.Player
{
    public class PlayerModel
    {
        private PlayerController playerController;

        public PlayerModel()
        {

        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }
    }
}

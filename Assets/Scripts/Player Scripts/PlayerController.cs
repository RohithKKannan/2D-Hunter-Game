using UnityEngine;

namespace Hunter.Player
{
    public class PlayerController
    {
        private PlayerModel playerModel;
        private PlayerView playerView;

        public PlayerController(PlayerView _playerPrefab)
        {
            playerModel = new PlayerModel();
            playerView = GameObject.Instantiate<PlayerView>(_playerPrefab);
        }
    }
}

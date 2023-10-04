using UnityEngine;

namespace Hunter.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }
    }
}

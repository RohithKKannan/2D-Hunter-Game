using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

namespace Hunter.Player
{
    public class PlayerService : GenericSingleton<PlayerService>
    {
        [SerializeField] private PlayerView playerPrefab;
        [SerializeField] private float playerSpeed = 5f;
        [SerializeField] private float playerHealth = 100f;

        private PlayerController player;

        public void SpawnPlayer(CinemachineVirtualCamera _camera)
        {
            player = new PlayerController(playerPrefab, playerSpeed, playerHealth, _camera);
        }

        public void RemovePlayer()
        {
            Destroy(player.playerView.gameObject);
        }
    }
}

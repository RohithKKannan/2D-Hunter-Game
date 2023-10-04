using Cinemachine;
using UnityEngine;

namespace Hunter.Player
{
    public class PlayerService : GenericSingleton<PlayerService>
    {
        [SerializeField] private PlayerView playerPrefab;
        [SerializeField] private float playerSpeed = 5f;

        private PlayerController player;

        public void SpawnPlayer(CinemachineVirtualCamera _camera)
        {
            player = new PlayerController(playerPrefab, playerSpeed, _camera);
        }
    }
}

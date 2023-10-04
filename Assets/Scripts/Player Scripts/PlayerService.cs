using UnityEngine;

namespace Hunter.Player
{
    public class PlayerService : GenericSingleton<PlayerService>
    {
        [SerializeField] private PlayerView playerPrefab;
        [SerializeField] private float playerSpeed = 5f;

        private PlayerController player;

        public void SpawnPlayer()
        {
            player = new PlayerController(playerPrefab, playerSpeed);
        }
    }
}

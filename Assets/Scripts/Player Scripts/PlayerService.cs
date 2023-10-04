using UnityEngine;

namespace Hunter.Player
{
    public class PlayerService : GenericSingleton<PlayerService>
    {
        [SerializeField] private PlayerView playerPrefab;

        private PlayerController player;

        private void CreateNewPlayer()
        {
            player = new PlayerController(playerPrefab);
        }
    }
}

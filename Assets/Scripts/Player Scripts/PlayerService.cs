using Cinemachine;
using Hunter.Bullet;
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

        public void SpawnPlayer(CinemachineVirtualCamera _camera, Camera _mainCamera)
        {
            player = new PlayerController(playerPrefab, playerSpeed, playerHealth, _camera, _mainCamera);
        }

        public void RemovePlayer()
        {
            Destroy(player.playerView.gameObject);
        }

        public void PlayerFireBullet(Vector2 _position, Vector2 _direction)
        {
            BulletService.Instance.SpawnBullet(_position, _direction);
        }
    }
}

using Cinemachine;
using UnityEngine;

namespace Hunter.Player
{
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }

        private Rigidbody2D rb;
        private Vector2 moveDirection;

        private float health;

        public PlayerController(PlayerView _playerPrefab, float _speed, float _health, CinemachineVirtualCamera _camera)
        {
            playerModel = new PlayerModel(_speed, _health);
            playerView = GameObject.Instantiate<PlayerView>(_playerPrefab, Vector3.zero, Quaternion.identity);

            playerModel.SetPlayerController(this);
            playerView.SetPlayerController(this);

            rb = playerView.GetPlayerRigidbody();
            _camera.Follow = playerView.transform;

            health = playerModel.health;
        }

        public void TakeDamage(float _damage)
        {
            health -= _damage;

            if (health <= 0)
            {
                PlayerDeath();
            }
        }

        public void Move(float _horizontal, float _vertical)
        {
            moveDirection = new Vector2(_horizontal, _vertical);
            rb.velocity = moveDirection * playerModel.speed;
        }

        private void PlayerDeath()
        {
            PlayerService.Instance.RemovePlayer();
        }
    }
}

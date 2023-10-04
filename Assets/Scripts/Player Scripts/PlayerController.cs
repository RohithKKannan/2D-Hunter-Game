using Cinemachine;
using UnityEngine;

namespace Hunter.Player
{
    public class PlayerController
    {
        private PlayerModel playerModel;
        private PlayerView playerView;

        private Rigidbody2D rb;
        private Vector2 moveDirection;
        public float moveSpeed = 5f;

        public PlayerController(PlayerView _playerPrefab, float _speed, CinemachineVirtualCamera _camera)
        {
            playerModel = new PlayerModel(_speed);
            playerView = GameObject.Instantiate<PlayerView>(_playerPrefab, Vector3.zero, Quaternion.identity);

            playerModel.SetPlayerController(this);
            playerView.SetPlayerController(this);

            rb = playerView.GetPlayerRigidbody();
            _camera.Follow = playerView.transform;
        }

        public void Move(float _horizontal, float _vertical)
        {
            moveDirection = new Vector2(_horizontal, _vertical);
            rb.velocity = moveDirection * moveSpeed;
        }
    }
}

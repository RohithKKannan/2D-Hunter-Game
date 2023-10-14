using System.Collections.Generic;
using System.Collections;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEditor;

namespace Hunter.Player
{
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }

        private Rigidbody2D rb;
        private Transform gun;
        private Vector2 moveDirection;

        private float health;
        private Camera mainCamera;

        public PlayerController(PlayerView _playerPrefab, float _speed, float _health, CinemachineVirtualCamera _camera, Camera _mainCamera)
        {
            playerModel = new PlayerModel(_speed, _health);
            playerView = GameObject.Instantiate<PlayerView>(_playerPrefab, Vector3.zero, Quaternion.identity);

            playerModel.SetPlayerController(this);
            playerView.SetPlayerController(this);

            rb = playerView.GetPlayerRigidbody();
            gun = playerView.GetPlayerGun();
            _camera.Follow = playerView.transform;

            mainCamera = _mainCamera;
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

        public void PlayerFireBullet()
        {
            Vector2 spawnPosition = gun.position;
            PlayerService.Instance.PlayerFireBullet(spawnPosition, rb.transform.right);
        }

        public void PlayerRotation()
        {
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = worldPos - rb.transform.position;
            direction.z = 0;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rb.transform.rotation = rotation;
        }
    }
}

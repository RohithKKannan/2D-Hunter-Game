using Hunter.Player;
using UnityEngine;
using Cinemachine;
using Hunter.Bullet;

namespace Hunter.GameLoop
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
        [SerializeField] private Camera mainCamera;

        [Header("GameObject Holders")]
        [SerializeField] private Transform bulletHolder;
        [SerializeField] private Transform enemyHolder;

        private void Start()
        {
            BulletService.Instance.SetBulletHolder(bulletHolder);
            PlayerService.Instance.SpawnPlayer(cinemachineVirtualCamera, mainCamera);
        }
    }
}

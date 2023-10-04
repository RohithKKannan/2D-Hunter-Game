using Hunter.Player;
using UnityEngine;
using Cinemachine;

namespace Hunter.GameLoop
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

        private void Start()
        {
            PlayerService.Instance.SpawnPlayer(cinemachineVirtualCamera);
        }
    }
}

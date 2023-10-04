using Hunter.Player;
using UnityEngine;

namespace Hunter.GameLoop
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            PlayerService.Instance.SpawnPlayer();
        }
    }
}

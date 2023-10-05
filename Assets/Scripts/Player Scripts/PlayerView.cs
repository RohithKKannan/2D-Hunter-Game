using UnityEngine;

namespace Hunter.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;
        private Rigidbody2D rb;

        public float horizontal;
        public float vertical;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }

        public Rigidbody2D GetPlayerRigidbody()
        {
            return rb;
        }

        private void GetInput()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        private void Update()
        {
            GetInput();

            playerController.Move(horizontal, vertical);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerController.PlayerFireBullet();
            }
        }
    }
}

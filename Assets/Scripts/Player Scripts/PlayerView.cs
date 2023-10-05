using System.Collections;
using UnityEngine;

namespace Hunter.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;
        private Rigidbody2D rb;

        private float horizontal;
        private float vertical;

        [SerializeField] private float timeBeforeNextShot = 0.1f;
        private bool canShoot = true;

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

            if (Input.GetMouseButton(0))
            {
                if (canShoot)
                {
                    playerController.PlayerFireBullet();
                    canShoot = false;
                    StartCoroutine(BulletTimeCounter());
                }
            }
        }

        IEnumerator BulletTimeCounter()
        {
            yield return new WaitForSeconds(timeBeforeNextShot);
            canShoot = true;
        }
    }
}

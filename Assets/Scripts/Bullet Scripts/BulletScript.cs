using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Hunter.Bullet
{
    public class BulletScript : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 25f;
        [SerializeField] private float timeToExpire = 1f;

        private Rigidbody2D rb;
        private float activeTime;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void LaunchBullet(Vector2 _direction)
        {
            rb.velocity = _direction * bulletSpeed;
            activeTime = 0f;
        }

        public void ResetBullet()
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        private void Update()
        {
            if (activeTime < timeToExpire)
            {
                activeTime += Time.deltaTime;
            }
            else
            {
                DeleteBullet();
            }
        }

        private void DeleteBullet()
        {
            ResetBullet();
            BulletService.Instance.DestroyBullet(this);
        }

        public void EnableBullet()
        {
            this.gameObject.SetActive(true);
        }

        public void DisableBullet()
        {
            this.gameObject.SetActive(false);
        }
    }
}

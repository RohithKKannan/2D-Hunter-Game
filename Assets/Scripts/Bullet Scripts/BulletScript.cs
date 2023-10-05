using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunter.Bullet
{
    public class BulletScript : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 10f;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void LaunchBullet(Vector2 _direction)
        {
            rb.velocity = new Vector2(1f, 0f) * bulletSpeed;
        }

        public void ResetBullet()
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}

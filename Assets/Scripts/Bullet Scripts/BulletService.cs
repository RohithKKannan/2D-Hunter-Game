using UnityEngine;

namespace Hunter.Bullet
{
    public class BulletService : GenericSingleton<BulletService>
    {
        [SerializeField] private BulletScript bulletPrefab;
        [SerializeField] private Transform bulletsHolder;

        public void SpawnBullet(Vector2 _position, Vector2 _direction)
        {
            BulletScript bullet = GameObject.Instantiate<BulletScript>(bulletPrefab, _position, Quaternion.identity);
            bullet.LaunchBullet(_direction);
            bullet.transform.SetParent(bulletsHolder, false);
        }
    }
}

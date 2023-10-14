using Hunter.ObjectPool;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Hunter.Bullet
{
    public class BulletService : GenericSingleton<BulletService>
    {
        [SerializeField] private BulletScript bulletPrefab;

        private Transform bulletsHolder;
        private BulletPoolScript bulletPool = new();

        protected override void Awake()
        {
            base.Awake();
            bulletPool.bulletPrefab = bulletPrefab;
        }

        public void SetBulletHolder(Transform _bulletHolder)
        {
            bulletsHolder = _bulletHolder;
        }

        public void SpawnBullet(Vector2 _position, Vector2 _direction)
        {
            BulletScript bullet = bulletPool.GetBullet();
            bullet.transform.position = _position;
            bullet.EnableBullet();
            bullet.LaunchBullet(_direction);
            bullet.transform.SetParent(bulletsHolder, false);
        }

        public void DestroyBullet(BulletScript _bullet)
        {
            _bullet.DisableBullet();
            bulletPool.ReturnBullet(_bullet);
        }
    }
}

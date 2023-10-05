using System.Collections.Generic;
using Hunter.Bullet;
using UnityEngine;

namespace Hunter.ObjectPool
{
    public class BulletPoolScript
    {
        private BulletScript bulletPrefab;
        private List<BulletPooledItem> pooledItems = new();

        public BulletScript GetBullet()
        {
            if (pooledItems.Count < 0)
                return null;

            BulletPooledItem bulletPooledItem = pooledItems.Find(newItem => newItem.isUsed == false);
            if (bulletPooledItem != null)
            {
                bulletPooledItem.isUsed = true;
                return bulletPooledItem.item;
            }

            BulletPooledItem newBulletPooledItem = new BulletPooledItem();
            newBulletPooledItem.item = CreateItem();
            newBulletPooledItem.isUsed = true;
            pooledItems.Add(newBulletPooledItem);
            return newBulletPooledItem.item;
        }

        public void ReturnBullet(BulletScript _item)
        {
            BulletPooledItem bulletPooledItem = pooledItems.Find(newItem => newItem.item == _item);
            if (bulletPooledItem != null)
            {
                bulletPooledItem.isUsed = false;
            }
        }

        public BulletScript CreateItem()
        {
            BulletScript bulletScript = GameObject.Instantiate<BulletScript>(bulletPrefab);
            return bulletScript;
        }
    }

    public class BulletPooledItem
    {
        public BulletScript item;
        public bool isUsed;
    }
}

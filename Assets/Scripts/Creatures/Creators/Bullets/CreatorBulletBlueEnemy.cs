using UnityEngine;
using Weapon.Bullet;

namespace Creators {
    public class CreatorBulletBlueEnemy : CreatorBase
    {
        private Transform _playerTransform;

        public CreatorBulletBlueEnemy(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public override GameObject Create()
        {
            GameObject bullet = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bullet Blue Enemy"));

            BullerBlueEnemy bulletBlueEnemy = bullet.AddComponent<BullerBlueEnemy>();

            bulletBlueEnemy.Init(_playerTransform);

            return bullet;
        }
    }
}

using UnityEngine;
using Weapon.Bullet;

namespace Creators
{
    public class CreatorBulletPlayer : CreatorBase
    {
        private Transform _weaponTransformForward;

        public CreatorBulletPlayer(Transform weaponTransformForward)
        {
            _weaponTransformForward = weaponTransformForward;
        }

        public override GameObject Create()
        {
            GameObject bullet = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bullet Player"));

            BulletPlayer bulletPlayer = bullet.AddComponent<BulletPlayer>();

            bulletPlayer.Init(_weaponTransformForward);

            return bullet;
        }
    }
}

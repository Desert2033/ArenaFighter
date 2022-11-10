using UnityEngine;
using Weapon;
using Creators;

namespace Player
{
    public class PlayerView : MonoBehaviour, IKilled
    {

        [SerializeField] private FixedJoystick _cameraRotateJoystick;

        [SerializeField] private FixedJoystick _playerMoveJoystick;

        [SerializeField] private WeaponView _playerWeapon;

        private WeaponController _weaponController;

        private PlayerController _controller;

        public void Init(PlayerController controller)
        {
            _controller = controller;

            CreatorBulletPlayer creatorBullet = new CreatorBulletPlayer(_playerWeapon.transform);

            WeaponModel weaponModel = new WeaponModel(coolDown : 1f);

            _weaponController = new WeaponController(weaponModel, _playerWeapon, creatorBullet);
        }

        private void FixedUpdate()
        {
            _controller.Move(_playerMoveJoystick, _cameraRotateJoystick);
        }

        public void OnTakeDamage(float damage)
        {
            _controller.TakeDamage(damage);
        }

        public void Shoot()
        {
            _weaponController.Shoot();
        }

        public void Kill()
        {
            gameObject.SetActive(false);
        }

        public void ReducePower(float reduce)
        {
            _controller.ReducePower(reduce);
        }

        public void Ultimate() 
        {
            foreach (var pool in EnemyPools.ListPools)
            {
                foreach (var item in pool.GetActiveItems())
                {
                    item.SetActive(false);
                }
            }
        }
    }
}

using Creators;
using Player;
using UnityEngine;
using UnityEngine.AI;
using Weapon;

namespace Enemies.BlueEnemy
{
    public class BlueEnemyController
    {
        private BlueEnemyModel _model;

        private BlueEnemyView _view;

        private Transform _player;

        private WeaponController _weaponController;

        private float _distaceFromPlayer = 1f;

        public BlueEnemyController(BlueEnemyView view, BlueEnemyModel model, Transform player)
        {
            _view = view;

            _model = model;

            _player = player;

            _view.Init(this);

            CreatorBulletBlueEnemy creatorBullet = new CreatorBulletBlueEnemy(_player);

            WeaponModel weaponModel = new WeaponModel(coolDown: 3f);

            _weaponController = new WeaponController(weaponModel, view.BlueEnemyWeapon, creatorBullet);

        }


        public void Move(NavMeshAgent navMeshAgent)
        {
            navMeshAgent.speed = _model.Speed;

            Vector3 newPosition = new Vector3(_player.position.x, _player.position.y, _player.position.z + _distaceFromPlayer);
                
            navMeshAgent.SetDestination(newPosition);

            _view.transform.LookAt(_player.transform);
        }

        public void Shoot()
        {
            Ray rayForward = new Ray(_view.transform.position, _view.transform.forward);

            if (Physics.Raycast(rayForward, out RaycastHit hit))
            {
                Transform target = hit.transform;

                if(target.TryGetComponent<PlayerView>(out PlayerView playerView))
                {
                    _weaponController.Shoot();
                }
            }
        }

        public void OnDisable()
        {
            _model = new BlueEnemyModel();
        }
    }
}

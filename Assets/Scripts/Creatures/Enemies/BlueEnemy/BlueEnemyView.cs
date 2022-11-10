using UnityEngine;
using UnityEngine.AI;
using Weapon;

namespace Enemies.BlueEnemy
{
    public class BlueEnemyView : MonoBehaviour, IKilled
    {
        [SerializeField] private WeaponView _blueEnemyWeapon;
        public WeaponView BlueEnemyWeapon => _blueEnemyWeapon;

        private BlueEnemyController _controller;

        private NavMeshAgent _thisNavMeshAgent;

        private void Update()
        {
            _controller.Move(_thisNavMeshAgent);
            _controller.Shoot();
        }

        private void OnEnable()
        {
            _thisNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void Init(BlueEnemyController controller)
        {
            _controller = controller;

            _thisNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void Kill()
        {
            gameObject.SetActive(false);
        }
    }
}

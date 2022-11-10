using UnityEngine;
using UnityEngine.AI;
using Player;

namespace Weapon.Bullet
{
    public class BullerBlueEnemy : MonoBehaviour
    {
        private Transform _playerTransform;

        private NavMeshAgent _thisNavMeshAgent;

        private float _reducePower = 25f;

        private void Start()
        {
            _thisNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            FollowPlayer();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.TryGetComponent<PlayerView>(out PlayerView playerView))
            {
                playerView.ReducePower(_reducePower);

                gameObject.SetActive(false);
            }
        }

        private void FollowPlayer()
        {
            _thisNavMeshAgent.SetDestination(_playerTransform.position);
        }
        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }
    }
}

using UnityEngine;
using Player;

namespace Enemies.RedEnemy
{
    public class RedEnemyView : MonoBehaviour, IKilled
    {
        private RedEnemyController _controller;

        public void Init(RedEnemyController controller)
        {
            _controller = controller;
        }

        private void Update()
        {
            _controller.Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerView>(out PlayerView playerView))
            {
                _controller.Damage(playerView);
                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            _controller.Disable();
        }

        public void Kill()
        {
            gameObject.SetActive(false);
        }
    }
}
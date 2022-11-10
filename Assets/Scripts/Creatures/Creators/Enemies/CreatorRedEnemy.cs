using Enemies.RedEnemy;
using UnityEngine;

namespace Creators
{
    public class CreatorRedEnemy : CreatorBase
    {
        private Transform _playerTransform;

        public CreatorRedEnemy(Transform player)
        {
            _playerTransform = player;
        }

        public override GameObject Create()
        {
            GameObject redEnemy = MonoBehaviour.Instantiate(
                Resources.Load<GameObject>("Prefabs/Enemies/Red Enemy"));

            RedEnemyView view = redEnemy.GetComponent<RedEnemyView>();

            RedEnemyModel model = new RedEnemyModel();

            RedEnemyController controller = new RedEnemyController(view, model, _playerTransform);

            return redEnemy;
        }
    }
}

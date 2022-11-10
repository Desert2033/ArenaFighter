using UnityEngine;
using Enemies.BlueEnemy;

namespace Creators
{
    public class CreatorBlueEnemy : CreatorBase
    {
        private Transform _playerTransform;

        public CreatorBlueEnemy(Transform player)
        {
            _playerTransform = player;
        }

        public override GameObject Create()
        {
            GameObject blueEnemy = MonoBehaviour.Instantiate(
                Resources.Load<GameObject>("Prefabs/Enemies/Blue Enemy"));

            BlueEnemyView view = blueEnemy.GetComponent<BlueEnemyView>();

            BlueEnemyModel model = new BlueEnemyModel();

            BlueEnemyController controller = new BlueEnemyController(view, model, _playerTransform);

            return blueEnemy;
        }
    }
}

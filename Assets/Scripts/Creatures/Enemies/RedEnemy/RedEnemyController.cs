using UnityEngine;
using Player;

namespace Enemies.RedEnemy
{
    public class RedEnemyController
    {

        private RedEnemyModel _model;

        private RedEnemyView _view;

        private Transform _playerTransform;

        private StateMachine _stateMachineRedEnemy;

        private float _maxUp = 2f;

        public RedEnemyController(RedEnemyView view, RedEnemyModel model, Transform playerTransform)
        {
            _view = view;

            _model = model;

            _playerTransform = playerTransform;

            _view.Init(this);

            _stateMachineRedEnemy = new StateMachine();

            _stateMachineRedEnemy.Init(new StateFly(_view.transform));
        }

        public void Move()
        {
            _stateMachineRedEnemy.CurrentState.Enter();

            if(_view.transform.position.y >= _maxUp)
            {
                _stateMachineRedEnemy.ChangeState(new StateMove(_view.transform, _playerTransform, _model.Speed));
            }
        }

        public void Damage(PlayerView player)
        {
            player.OnTakeDamage(_model.Damage);
        }

        public void Disable()
        {
            _stateMachineRedEnemy.ChangeState(new StateFly(_view.transform));
        }
    }
}

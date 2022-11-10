using UnityEngine;

namespace Enemies.RedEnemy
{
    public class StateMove : IState
    {

        private Transform _moveble;

        private Transform _lookAt;

        private float _speed;

        public StateMove(Transform moveble, Transform lookAt, float speed)
        {
            _moveble = moveble;

            _lookAt = lookAt;

            _speed = speed;
        }

        public void Enter()
        {
            _moveble.LookAt(_lookAt);

            _moveble.localPosition += _moveble.forward * Time.deltaTime * _speed;
        }

        public void Exit()
        {
        }
    }
}

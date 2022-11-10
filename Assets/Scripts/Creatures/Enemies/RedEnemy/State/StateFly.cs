using UnityEngine;

namespace Enemies.RedEnemy
{
    public class StateFly : IState
    {
        private Transform _moveble;

        public StateFly(Transform moveble)
        {
            _moveble = moveble;
        }

        public void Enter()
        {
            _moveble.localPosition += _moveble.up * Time.deltaTime * 1f;
        }

        public void Exit()
        {
        }
    }
}

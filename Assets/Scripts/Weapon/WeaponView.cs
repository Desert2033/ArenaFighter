using UnityEngine;

namespace Weapon
{
    public class WeaponView : MonoBehaviour
    {

        [SerializeField] private Transform _pointBulletPosition;
        public Transform PointBulletPosition => _pointBulletPosition;

        private WeaponController _controller;

        private void Update()
        {
            _controller.ReadyCoolDown();
        }

        public void Init(WeaponController controller)
        {
            _controller = controller;
        }
    }
}

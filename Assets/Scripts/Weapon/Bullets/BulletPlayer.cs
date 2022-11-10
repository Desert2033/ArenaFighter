using UnityEngine;

namespace Weapon.Bullet {
    public class BulletPlayer : MonoBehaviour
    {
        private Rigidbody _bulletRigidbody;

        private Transform _weaponTransformForward;

        private float _speed = 5f;

        private void Start()
        {
            _bulletRigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent<IKilled>(out IKilled objectKilled))
            {
                objectKilled.Kill();
            }
            
            gameObject.SetActive(false);
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _bulletRigidbody.velocity = _weaponTransformForward.forward * _speed;
        }

        public void Init(Transform weaponTransformForward)
        {
            _weaponTransformForward = weaponTransformForward;
        }
    }
}


using UnityEngine;
using Creators;

namespace Weapon
{
    public class WeaponController
    {
        private WeaponModel _model;

        private WeaponView _view;

        private Pool _poolBullets;

        private CreatorBase _creatorBullet;

        public WeaponController(WeaponModel model, WeaponView view, CreatorBase creatorBullet)
        {
            _model = model;

            _creatorBullet = creatorBullet;

            _poolBullets = new Pool(_creatorBullet, 1);

            _view = view;

            _view.Init(this);
        }

        public bool ReadyCoolDown()
        {
            if (_model.CurrentCoolDown >= _model.CoolDown)
            {
                return true;
            }

            _model.CurrentCoolDown += Time.deltaTime;

            return false;
        }

        public void Shoot()
        {
            if (ReadyCoolDown())
            {
                GameObject bulletGameObject = _poolBullets.GetFreeItem();

                bulletGameObject.transform.position = _view.PointBulletPosition.position;

                bulletGameObject.SetActive(true);

                _model.CurrentCoolDown = 0;
            }
        }
    }
}

using System;
using UnityEngine;

namespace Player {
    public class PlayerController
    {
        private PlayerModel _model;

        private PlayerView _view;

        private CameraFollow _mainCamera;

        public Action _OnDie;

        public PlayerController(PlayerView view, PlayerModel model)
        {
            _model = model;

            _view = view;

            _mainCamera = Camera.main.gameObject.GetComponent<CameraFollow>();

            _view.Init(this);

            _mainCamera.Init(_view.transform);
        }

        public void Move(FixedJoystick playerMoveJoystick, FixedJoystick cameraRotateJoystick)
        {
            float vertical = playerMoveJoystick.Vertical;

            float horizontal = playerMoveJoystick.Horizontal;

            if (vertical >= 0.5f)
            {
                _view.transform.localPosition += _view.transform.forward * Time.deltaTime * _model.Speed;
            }
            if (vertical <= -0.5f)
            {
                _view.transform.localPosition += -_view.transform.forward * Time.deltaTime * _model.Speed;
            }
            if (horizontal >= 0.5f)
            {
                _view.transform.localPosition += _view.transform.right * Time.deltaTime * _model.Speed;
            }
            if (horizontal <= -0.5f)
            {
                _view.transform.localPosition += -_view.transform.right * Time.deltaTime * _model.Speed;
            }

            _mainCamera.Rotate(cameraRotateJoystick);
        }

        public void TakeDamage(float damage)
        {
            _model.CurrentHp -= damage;
            
            if (_model.CurrentHp < 0)
            {
                _model.CurrentHp = 0;
                _OnDie?.Invoke();
            }
        }

        public void ReducePower(float reduce)
        {
            _model.CurrentPower -= reduce;
            
            if (_model.CurrentPower < 0)
            {
                _model.CurrentPower = 0;
            }
        }
    }
}
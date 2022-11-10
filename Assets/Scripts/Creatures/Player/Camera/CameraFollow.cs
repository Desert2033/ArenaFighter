using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {

        private Transform _playerTranform;

        private float _rotateSensitive = 100f;

        private float _yRotation = 0f;

        public void Init(Transform playerTransform)
        {
            _playerTranform = playerTransform;
        }

        public void Rotate(FixedJoystick rotate)
        {

            float rotateY = rotate.Vertical * _rotateSensitive * Time.deltaTime;

            float rotateX = rotate.Horizontal * _rotateSensitive * Time.deltaTime;

            _yRotation -= rotateY;
            _yRotation = Mathf.Clamp(_yRotation, -90f, 0f);

            transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);

            _playerTranform.Rotate(Vector3.up * rotateX);
        }

    }
}
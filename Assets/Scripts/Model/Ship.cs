using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class Ship : MonoBehaviour, IAircraft
    {
        [SerializeField] private Transform _pointWeapon;
        [SerializeField] private float _maxSpeed = 1f;
        [SerializeField] private float _speedRotation = 1f;
        [SerializeField] private float _acceleration = 1f;

        private Rigidbody _playerRigidbody;
        private Vector3 _impulseMovement;
        private float _rotation;
        private Vector3 _lastPosition;
        private Vector3 _currentPosition;
        private float _speed;

        public Weapon Weapon { get; private set; }
        public Transform PointWeapon => _pointWeapon;

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
            _lastPosition = transform.position;
        }

        public void Move(float move)
        {
            if (_speed <= _maxSpeed)
            {
                _impulseMovement = move * _acceleration * Time.deltaTime * transform.up;
                _playerRigidbody.AddForce(_impulseMovement, ForceMode.Force);
            }
        }

        public void CheckSpeed()
        {
            _currentPosition = transform.position;
            _speed = Vector3.Distance(_currentPosition, _lastPosition);
            _lastPosition = _currentPosition;
        }

        public void Rotate(float rotate)
        {
            _rotation = rotate * _speedRotation;
            transform.Rotate(Vector3.forward, _rotation * Time.deltaTime);
        }

        internal void SetParameters(float maxSpeed, float acceleration, float speedRotation)
        {
            _speedRotation = speedRotation;
            _maxSpeed = maxSpeed;
            _acceleration = acceleration;
        }

        internal void Equip(Weapon weapon)
        {
            Weapon = weapon;
        }
    }
}
